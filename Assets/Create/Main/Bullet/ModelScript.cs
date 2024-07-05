using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ModelScript : MonoBehaviourPunCallbacks
{

    void Start()
    {

    }

    void Update()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Me");
        Vector3 player = obj.transform.position;
        this.transform.position = player;

    }
}
