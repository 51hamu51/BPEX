using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TiredTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    void Start()
    {

    }


    void Update()
    {


        if (PlayerScript.stamina == 0 && PauseTextScript.Pause == 1)
        {
            Text.text = string.Format("Tired");
        }
        else
        {
            Text.text = string.Format("");
        }

    }
}
