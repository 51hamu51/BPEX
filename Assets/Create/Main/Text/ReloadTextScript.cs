using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReloadTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    void Start()
    {

    }


    void Update()
    {



        if (PauseTextScript.Pause == 0)
        {
            Text.text = string.Format("");
        }
        else if (FireScript.reloadMana == 1)
        {
            Text.text = string.Format("reloading...");
        }
        else
        {
            Text.text = string.Format("");
        }

    }
}
