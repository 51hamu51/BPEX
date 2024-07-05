using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrassHopperScript : MonoBehaviourPunCallbacks
{
    private float deleteTime = 3.0f;

    void Start()
    {
        Destroy(gameObject, deleteTime);
    }


    void Update()
    {



    }

}
