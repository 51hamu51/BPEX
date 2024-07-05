using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceColorScript : MonoBehaviour
{
    private GameObject obj;
    private Color defaultcolor;

    void Start()
    {
        obj = this.gameObject;
        defaultcolor = obj.GetComponent<Renderer>().material.color;
    }


    void Update()
    {


        if (FireScript.chameleonC == 1)
        {
            defaultcolor.a = 0.3f;
            GetComponent<Renderer>().material.color = defaultcolor;

        }
        else
        {
            defaultcolor.a = 1.0f;
            GetComponent<Renderer>().material.color = defaultcolor;

        }
    }
}
