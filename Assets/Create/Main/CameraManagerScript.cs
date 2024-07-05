using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraManagerScript : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject maincamera;
    [SerializeField] GameObject backcamera;

    void Start()
    {
        maincamera.SetActive(true);
        backcamera.SetActive(false);
    }


    void Update()
    {
        if (maincamera != null)
        {
            if (Input.GetKey("space"))
            {
                maincamera.SetActive(false);
                backcamera.SetActive(true);
            }
            else
            {
                maincamera.SetActive(true);
                backcamera.SetActive(false);
            }
        }
    }
}
