using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public int SetBu = 0;
    public string Bula;
    public string Bulb;

    public static string[] Bul = { "asteroid", "meteora", "hound", "shield", "kogetu", "grasshopper", "escudo", "free", "free2", "free3" }; /*, "chameleon", , "leadbullet"*/

    private int x, y;


    void Update()
    {



        if (PauseTextScript.Pause == 0)
        {
            Text.text = string.Format("press each button if you want to swap");




        }
        else if (PauseTextScript.Pause == 1)
        {
            Text.text = string.Format("");
        }
    }
}
