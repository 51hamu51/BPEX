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
        if (!photonView.IsMine)
        {
            return;
        }

        StartCoroutine(AutoDestroyCoroutine());

        //発射されたタイミングで正面の敵を感知
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            // 敵（Playerタグ）が正面に見えたら、その敵を追尾
            if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("PlayerParts"))
            {
                rival = hit.collider.gameObject;
                photonView.RPC("ChangeColorToOrange", RpcTarget.AllBuffered);
            }

        }


        InvokeRepeating("Search", 0, 0.1f);
    }

    /// <summary>
    /// 追跡時に色を変える
    /// </summary>
    [PunRPC]
    void ChangeColorToOrange()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = new Color(1.0f, 0.65f, 0.0f);
        }
    }

    IEnumerator AutoDestroyCoroutine()
    {
        yield return new WaitForSeconds(deleteTime);
        PhotonNetwork.Destroy(gameObject);
    }

    void Update()
    {
        if (!photonView.IsMine) return;

        this.transform.position += speed * this.transform.forward * Time.deltaTime;
    }

    /// <summary>
    /// ターゲットの方向を向く
    /// </summary>
    void Search()
    {
        if (!photonView.IsMine) return;

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
            playerHPS.Damage(1);
            PlayerScript.damage = 1;
            if (playerHPS.GetHP() <= 0)
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
            playerHPS.Damage(1);
            PlayerScript.damage = 1;
            if (playerHPS.GetHP() <= 0)
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
