using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class LeadbulletScript : MonoBehaviourPunCallbacks
{
    private float deleteTime = 3.0f;

    void Start()
    {
        Destroy(gameObject, deleteTime);
    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Me"))
        {
            PlayerScript.lead = 1;
        }
        if (collider.gameObject.CompareTag("Player"))
        {

            Invoke(nameof(BulletDest), 0.1f);

        }
        if (collider.gameObject.CompareTag("Chameleon"))
        {
            PlayerScript.lead = 1;
            Invoke(nameof(BulletDest), 0.1f);
        }
        if (collider.gameObject.CompareTag("Shield"))
        {

            PhotonNetwork.Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("Struct"))
        {

            PhotonNetwork.Destroy(gameObject);
        }
    }

    void BulletDest()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
