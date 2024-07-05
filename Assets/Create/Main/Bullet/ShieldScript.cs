using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShieldScript : MonoBehaviourPunCallbacks
{

    void Start()
    {

    }


    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        GameObject obj = GameObject.FindGameObjectWithTag("Me");

        if (PlayerScript.stamina > 0)
        {



            PlayerScript.stamina -= Time.deltaTime * 2;

            if (PlayerScript.stamina <= 0)
            {
                PhotonNetwork.Destroy(gameObject);
                PlayerScript.stamina = 0;

                FireScript.shieldC = 0;
            }
        }
        Vector3 player = obj.transform.position;
        this.transform.position = player;

        if (Input.GetMouseButtonDown(0))
        {
            FireScript.shieldC = 0;
            PhotonNetwork.Destroy(gameObject);

        }
        if (SettingTextScript.Bul[FireScript.bulletmode - 1] != "shield")
        {

            FireScript.shieldC = 0;
            PhotonNetwork.Destroy(gameObject);
        }

    }
}
