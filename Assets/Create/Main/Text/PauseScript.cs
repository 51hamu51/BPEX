using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PauseTextScript.Pause == 1)
        {
            PauseTextScript.Pause = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseTextScript.Pause == 0)
        {
            PauseTextScript.Pause = 1;
        }
    }
}
