using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    [SerializeField] GameObject Light;
    void Start()
    {

    }

    void Update()
    {
        if (PauseTextScript.Pause == 1)
        {
            Light.SetActive(true);


        }
        else
        {
            Light.SetActive(false);


        }

    }
}
