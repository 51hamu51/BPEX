using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaminaTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    void Start()
    {

    }


    void Update()
    {
        float st = PlayerScript.stamina * 1000;
        if (PauseTextScript.Pause == 0)
        {
            Text.text = string.Format("");
        }
        else
        {
            Text.text = string.Format("<alpha=#33>stamina : {0} / 5000", st.ToString("f0").PadLeft(4, '0'));
        }


    }
}
