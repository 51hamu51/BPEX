using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ReMeteoraScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform firingPoint;



    public float deleteTimeC = 0.0f;
    private float speed = 300f;


    void Start()
    {

    }


    void Update()
    {
        deleteTimeC += Time.deltaTime;
        if (deleteTimeC > 1.5f)
        {

            Invoke(nameof(Explosion), 0.1f);

            /*   Invoke(nameof(BulletDest), 0.2f); */





        }
    }
    public void Explosion()
    {

        GameObject bullet = PhotonNetwork.Instantiate("explode", Vector3.zero, Quaternion.identity, 0) as GameObject;


        bullet.transform.position = firingPoint.position;

        PhotonNetwork.Instantiate("ExplosionPartcle", transform.position, Quaternion.Euler(-90, 0, 0));

        BulletDest();


    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Me"))
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
        if (collider.gameObject.CompareTag("Player"))
        {
            /*  collider.gameObject.GetComponent<PlayerScript>().TagChangeDame();
             collider.gameObject.GetComponent<PlayerScript>().TagChangeDame2(); */
            Invoke(nameof(BulletDest), 0.1f);

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
