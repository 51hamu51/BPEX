using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MeteoraScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform firingPoint;
    [SerializeField]
    private Transform firingPoint2;
    [SerializeField]
    private Transform firingPoint3;
    [SerializeField]
    private GameObject bullet;

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

            Invoke(nameof(SplitBullet), 0.1f);

            Invoke(nameof(BulletDest), 0.3f);





        }
    }
    public void SplitBullet()
    {
        GameObject bullets = PhotonNetwork.Instantiate("bullet", Vector3.zero, Quaternion.identity, 0) as GameObject;
        GameObject bullet2 = PhotonNetwork.Instantiate("bullet", Vector3.zero, Quaternion.identity, 0) as GameObject;
        GameObject bullet3 = PhotonNetwork.Instantiate("bullet", Vector3.zero, Quaternion.identity, 0) as GameObject;
        GameObject bullet4 = PhotonNetwork.Instantiate("bullet", Vector3.zero, Quaternion.identity, 0) as GameObject;
        Vector3 force;
        Vector3 force2;
        Vector3 force3;
        Vector3 force4;
        force = this.gameObject.transform.forward * speed;
        force2 = this.gameObject.transform.right * speed;
        force3 = this.gameObject.transform.right * -speed;
        force4 = this.gameObject.transform.up * -speed;
        bullets.GetComponent<Rigidbody>().AddForce(force);
        bullet2.GetComponent<Rigidbody>().AddForce(force2);
        bullet3.GetComponent<Rigidbody>().AddForce(force3);
        bullet3.GetComponent<Rigidbody>().AddForce(force4);
        bullets.transform.position = firingPoint.position;
        bullet2.transform.position = firingPoint.position;
        bullet3.transform.position = firingPoint.position;
        bullet4.transform.position = firingPoint2.position;

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
