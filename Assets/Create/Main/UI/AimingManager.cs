using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingManager : MonoBehaviour
{
    [SerializeField] private GameObject aiming;

    private FireScript fireScript;

    /// <summary>
    /// まっすぐ飛ぶ武器
    /// </summary>
    private HashSet<string> aimingWeapons = new HashSet<string> { "asteroid", "meteora", "leadbullet" };

    void Start()
    {
        aiming.SetActive(false);
    }

    void Update()
    {
        if (fireScript == null)
        {
            GameObject meObj = GameObject.FindWithTag("Me");
            if (meObj != null)
            {
                fireScript = meObj.GetComponent<FireScript>();
            }
        }

        if (fireScript == null)
        {
            return;
        }

        //対象武器名に含まれるかチェック
        aiming.SetActive(aimingWeapons.Contains(fireScript.WeaponName()) && PauseTextScript.Pause == 1);
    }
}
