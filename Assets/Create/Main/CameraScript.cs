/*他者が作成したプログラムを自身で変更*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraScript : MonoBehaviourPunCallbacks
{

    void Start()
    {

    }

    void Update()
    {
        float my = Input.GetAxis("Mouse Y");
        GameObject me = GameObject.FindWithTag("Me");
        if (me != null)
        {
            GetComponent<Camera>().transform.parent = me.transform;
            GetComponent<Camera>().transform.position = me.transform.position;
            transform.position += transform.forward * -5;
            transform.position += transform.up * 2;
            if (Mathf.Abs(my) > 0.001f)
            {
                if (PauseTextScript.Pause == 1)
                {
                    transform.RotateAround(me.transform.position, transform.right, -my);
                }
            }
        }


    }


}
