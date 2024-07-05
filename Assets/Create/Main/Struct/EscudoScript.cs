using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EscudoScript : MonoBehaviourPunCallbacks
{

    private int EsHP = 5;
    void Start()
    {

    }


    void Update()
    {
        if (EsHP <= 0)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            if (!photonView.IsMine)
            {
                gameObject.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
            }
            EsHP--;

        }
    }
}
