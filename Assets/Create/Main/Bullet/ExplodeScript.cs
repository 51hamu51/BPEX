using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ExplodeScript : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(BulletDest), 0.2f);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Shield"))
        {

            PhotonNetwork.Destroy(gameObject);
        }
        else if (collider.gameObject.CompareTag("Me"))
        {
            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            playerHPS.PlayerHP -= 2;
            PlayerScript.damage = 1;
            if (playerHPS.PlayerHP <= 0)
            {

                collider.gameObject.GetComponent<PlayerScript>().Killnum(photonView.Owner.ActorNumber, photonView.Owner.NickName);
            }

        }
        if (collider.gameObject.CompareTag("Player"))
        {
            /*  collider.gameObject.GetComponent<PlayerScript>().TagChangeDame();
             collider.gameObject.GetComponent<PlayerScript>().TagChangeDame2(); */
            Invoke(nameof(BulletDest), 1.0f);

        }
        if (collider.gameObject.CompareTag("Chameleon"))
        {
            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            playerHPS.PlayerHP -= 2;
            PlayerScript.damage = 1;
            if (playerHPS.PlayerHP <= 0)
            {

                collider.gameObject.GetComponent<PlayerScript>().Killnum(photonView.Owner.ActorNumber, photonView.Owner.NickName);
            }

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
