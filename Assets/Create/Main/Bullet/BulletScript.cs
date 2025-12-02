using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class BulletScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI MembersText;
    private float deleteTime = 8.0f;
    int t;

    void Start()
    {
        if (photonView.IsMine)
        {
            StartCoroutine(AutoDestroyCoroutine());
        }
    }

    /// <summary>
    /// 時限削除用のコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator AutoDestroyCoroutine()
    {
        yield return new WaitForSeconds(deleteTime);
        // 時間が来たらネットワーク上から削除
        PhotonNetwork.Destroy(gameObject);
    }


    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Me"))
        {

            PlayerScript.damage = 1;
            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            playerHPS.PlayerHP -= 1;

            if (playerHPS.PlayerHP <= 0)
            {

                collider.gameObject.GetComponent<PlayerScript>().Killnum(photonView.Owner.ActorNumber, photonView.Owner.NickName);


            }

        }
        if (collider.gameObject.CompareTag("Player"))
        {

            /* collider.gameObject.GetComponent<PlayerScript>().TagChangeDame();
            collider.gameObject.GetComponent<PlayerScript>().TagChangeDame2(); */


            Invoke(nameof(BulletDest), 0.1f);

        }
        if (collider.gameObject.CompareTag("Chameleon"))
        {
            PlayerScript.damage = 1;
            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            playerHPS.PlayerHP -= 1;
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
