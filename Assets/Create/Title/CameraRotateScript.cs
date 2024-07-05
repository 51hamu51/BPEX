using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateScript : MonoBehaviour
{
    float speed = 0.01f;

    void Start()
    {

    }


    void Update()
    {
        this.transform.Rotate(0, speed, 0);
    }
}
