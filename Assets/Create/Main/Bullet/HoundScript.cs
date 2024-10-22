using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class HoundScript : MonoBehaviourPunCallbacks
{

    private GameObject rival;
    private int speed = 15;
    private float deleteTime = 3.0f;

    void Start()
    {
        Destroy(gameObject, deleteTime);
        InvokeRepeating("Seach", 0, 1);
    }


    void Update()
    {

        this.transform.position += speed * this.transform.forward * Time.deltaTime;
    }
    void Seach()
    {
        rival = GameObject.FindGameObjectWithTag("Player");
        if (rival != null)
        {
            this.transform.LookAt(rival.transform);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Me"))
        {
            if (photonView.IsMine)
            {
                return;
            }
            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            playerHPS.PlayerHP -= 1;
            PlayerScript.damage = 1;
            if (playerHPS.PlayerHP <= 0)
            {

                collider.gameObject.GetComponent<PlayerScript>().Killnum(photonView.Owner.ActorNumber, photonView.Owner.NickName);
            }
        }
        if (collider.gameObject.CompareTag("Player"))
        {
            /* collider.gameObject.GetComponent<PlayerScript>().TagChangeDame();
            collider.gameObject.GetComponent<PlayerScript>().TagChangeDame2(); */
            Invoke(nameof(BulletDest), 0.2f);

        }
        if (collider.gameObject.CompareTag("Chameleon"))
        {
            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            playerHPS.PlayerHP -= 1;
            PlayerScript.damage = 1;
            if (playerHPS.PlayerHP <= 0)
            {

                collider.gameObject.GetComponent<PlayerScript>().Killnum(photonView.Owner.ActorNumber, photonView.Owner.NickName);
            }

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

    /*botを復活させるとき用*/
    /*    private void OnCollisionEnter(Collision collision)
       {
           if (collision.gameObject.CompareTag("Enemy"))
           {
               EnemyHPScript EnemyHPS;
               GameObject obj = GameObject.Find("EnemyObserver");
               EnemyHPS = obj.GetComponent<EnemyHPScript>();
               EnemyHPS.EnemyHP -= 1;
               Destroy(gameObject);
           }
           if (collision.gameObject.CompareTag("Shield"))
           {

               Destroy(gameObject);
           }
       } */
    void BulletDest()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
