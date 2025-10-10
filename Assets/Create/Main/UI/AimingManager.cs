using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimingManager : MonoBehaviour
{
    [SerializeField] private GameObject aiming;

    private FireScript fireScript;

    [SerializeField] private Sprite NoAim;
    [SerializeField] private Sprite CaptureAim;

    [SerializeField] private int defaultSize;
    [SerializeField] private int CaptureSize;

    /// <summary>
    /// まっすぐ飛ぶ武器
    /// </summary>
    private HashSet<string> aimingWeapons = new HashSet<string> { "asteroid", "meteora", "leadbullet", "hound" };

    private RectTransform aimingRectTransform;

    void Start()
    {
        aiming.SetActive(false);
        aimingRectTransform = aiming.GetComponent<RectTransform>();
    }

    void Update()
    {
        AimCheck();

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

    /// <summary>
    /// 敵にエイムがあっていればアイコンを変える
    /// </summary>
    void AimCheck()
    {
        //アイコンを通常に戻す
        aiming.GetComponent<Image>().sprite = NoAim;
        aimingRectTransform.sizeDelta = new Vector2(defaultSize, defaultSize);

        if (fireScript == null)
        {
            return;
        }

        if (fireScript.WeaponName() != "hound")
        {
            return;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            // 敵（Playerタグ）が正面に見えたら
            if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("PlayerParts"))
            {
                aiming.GetComponent<Image>().sprite = CaptureAim;
                aimingRectTransform.sizeDelta = new Vector2(CaptureSize, CaptureSize);
            }
        }
    }
}
