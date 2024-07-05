using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManegerScript : MonoBehaviour
{
    [SerializeField] GameObject Panel;

    void Start()
    {

    }


    void Update()
    {
        if (PauseTextScript.Pause == 1)
        {
            Panel.SetActive(false);
        }
        else if (PauseTextScript.Pause == 0)
        {
            Panel.SetActive(true);
        }
    }
}
