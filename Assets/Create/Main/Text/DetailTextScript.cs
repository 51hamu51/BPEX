using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DetailTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public static int DetailNum = -1;

    void Start()
    {
        Text.text = string.Format("");
    }


    void Update()
    {
        if (PauseTextScript.Pause == 1)
        {
            Text.text = string.Format("");
        }
        else if (PauseTextScript.Pause == 0)
        {
            if (DetailNum == -1)
            {
                Text.text = string.Format("");
            }
            else if (SettingTextScript.Bul[DetailNum] == "asteroid")
            {
                Text.text = string.Format("normal bullet");
            }
            else if (SettingTextScript.Bul[DetailNum] == "chameleon")
            {
                Text.text = string.Format("invisible");
            }
            else if (SettingTextScript.Bul[DetailNum] == "leadbullet")
            {
                Text.text = string.Format("bind bullet");
            }
            else if (SettingTextScript.Bul[DetailNum] == "meteora")
            {
                Text.text = string.Format("explode bullet");
            }
            else if (SettingTextScript.Bul[DetailNum] == "hound")
            {
                Text.text = string.Format("chase bullet");
            }
            else if (SettingTextScript.Bul[DetailNum] == "shield")
            {
                Text.text = string.Format("shield");
            }
            else if (SettingTextScript.Bul[DetailNum] == "kogetu")
            {
                Text.text = string.Format("sword");
            }
            else if (SettingTextScript.Bul[DetailNum] == "grasshopper")
            {
                Text.text = string.Format("jump");
            }
            else if (SettingTextScript.Bul[DetailNum] == "escudo")
            {
                Text.text = string.Format("build wall");
            }
            else if (SettingTextScript.Bul[DetailNum] == "free")
            {
                Text.text = string.Format("free");
            }
            else if (SettingTextScript.Bul[DetailNum] == "free2")
            {
                Text.text = string.Format("free");
            }
            else if (SettingTextScript.Bul[DetailNum] == "free3")
            {
                Text.text = string.Format("free");
            }
        }
    }
}
