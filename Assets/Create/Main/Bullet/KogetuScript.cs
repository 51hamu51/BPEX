using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class KogetuScript : MonoBehaviourPunCallbacks
{
    private int blade;


    void Start()
    {
        blade = 0;

    }


    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        GameObject obj2 = GameObject.FindGameObjectWithTag("Me");

        GameObject obj3 = GameObject.FindGameObjectWithTag("BladePoint");

        Vector3 kogetu = obj3.transform.position;
        Vector3 local = obj2.transform.localEulerAngles;



        this.transform.position = kogetu;
        if (Input.GetMouseButtonDown(0) && PauseTextScript.Pause == 1 && blade == 0)
        {

            local.x = 90;
            this.transform.localEulerAngles = local;
            blade = 1;
        }
        if (Input.GetMouseButton(0) && PauseTextScript.Pause == 1)
        {

            local.x = 90;
            this.transform.localEulerAngles = local;

        }
        if (Input.GetMouseButtonUp(0) && PauseTextScript.Pause == 1 && blade == 1)
        {

            local.x = 0;
            this.transform.localEulerAngles = local;
            blade = 0;
        }
        if (PauseTextScript.Pause == 0 && blade == 1)
        {


            local.x = 0;
            this.transform.localEulerAngles = local;
            blade = 0;

        }



        if (SettingTextScript.Bul[FireScript.bulletmode - 1] != "kogetu")
        {

            FireScript.kogetuC = 0;
            PhotonNetwork.Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (photonView.IsMine)
        {
            return;
        }
        if (collider.gameObject.CompareTag("Me"))
        {

            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            playerHPS.PlayerHP -= 3;
            PlayerScript.damage = 1;
            if (playerHPS.PlayerHP <= 0)
            {

                collider.gameObject.GetComponent<PlayerScript>().Killnum(photonView.Owner.ActorNumber, photonView.Owner.NickName);
            }

        }
        if (collider.gameObject.CompareTag("Chameleon"))
        {

            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            playerHPS.PlayerHP -= 3;
            PlayerScript.damage = 1;
            if (playerHPS.PlayerHP <= 0)
            {

                collider.gameObject.GetComponent<PlayerScript>().Killnum(photonView.Owner.ActorNumber, photonView.Owner.NickName);
            }

        }
    }
}
