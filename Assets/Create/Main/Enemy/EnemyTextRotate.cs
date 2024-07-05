using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTextRotate : MonoBehaviour
{
    private GameObject Camera;
    private GameObject Camera2;

    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        Camera2 = GameObject.Find("BackCamera");
        if (Camera != null)
        {
            transform.LookAt(Camera.transform);
        }
        else if (Camera2 != null)
        {
            transform.LookAt(Camera2.transform);
        }
    }


    void Update()
    {
        Camera = GameObject.Find("Main Camera");
        Camera2 = GameObject.Find("BackCamera");
        if (Camera != null)
        {
            transform.LookAt(Camera.transform);
        }
        else if (Camera2 != null)
        {
            transform.LookAt(Camera2.transform);
        }

    }
}
