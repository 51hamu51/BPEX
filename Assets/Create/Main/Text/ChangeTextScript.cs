using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    private int x;
    private int y;
    public static int X = -1;
    public static int Y = -1;

    void Start()
    {

    }


    void Update()
    {
        if (PauseTextScript.Pause == 0)
        {
            if (X == -1 && Y == -1)
            {
                Text.text = string.Format("        <->        ");
            }
            else if (X != -1 && Y == -1)
            {
                Text.text = string.Format("{0}.{1}  <->        ", X + 1, SettingTextScript.Bul[X]);
            }
            else
            {
                Text.text = string.Format("{0}.{1}  <->{2}.{3}  ", X + 1, SettingTextScript.Bul[X], Y + 1, SettingTextScript.Bul[Y]);
                (SettingTextScript.Bul[X], SettingTextScript.Bul[Y]) = (SettingTextScript.Bul[Y], SettingTextScript.Bul[X]);
                X = -1;
                Y = -1;
            }



        }
        else if (PauseTextScript.Pause == 1)
        {
            Text.text = string.Format("");
        }
    }
}