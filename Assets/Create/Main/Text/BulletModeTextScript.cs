using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletModeTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    void Start()
    {

    }


    void Update()
    {
        FireScript FireS;
        PlayerHPScript playerHPS;
        GameObject obj = GameObject.Find("PlayerObserver");
        playerHPS = obj.GetComponent<PlayerHPScript>();
        GameObject obj2 = playerHPS.playerobj;
        FireS = obj2.GetComponent<FireScript>();

        if (PauseTextScript.Pause == 0)
        {
            Text.text = string.Format("");
        }
        else
        {

            Text.text = string.Format("<alpha=#33>mode{0} :{1}", FireScript.bulletmode, SettingTextScript.Bul[FireScript.bulletmode - 1]);


        }
    }
}
