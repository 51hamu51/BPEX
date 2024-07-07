using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerScript : MonoBehaviourPunCallbacks
{
    public float speed = 5.0f;


    public static float stamina;
    public float staminaM = 5.0f;

    public static int lead = 0;
    public static int damage = 0;
    public static int point = 0;
    private int restart = 0;

    private int killnumber;
    private string killname;





    void Start()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        if (photonView.IsMine)
        {
            stamina = 5.0f;
            if (this.tag != "Dame")
            {
                this.tag = "Me";
            }
            ResultTextScript.retire = 0;

            ResultTextScript.fall = 0;
        }


    }

    void Update()
    {

        if (!photonView.IsMine)
        {

            return;
        }

        if (photonView.IsMine)
        {
            if (PhotonNetwork.LocalPlayer.ActorNumber >= 0)
            {
                MemberScript.Point[PhotonNetwork.LocalPlayer.ActorNumber] = point;
            }

            if (this.tag != "Dame")
            {
                this.tag = "Me";
            }


            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            if (playerHPS.PlayerHP > 0 && PauseTextScript.Pause == 1)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position += speed * transform.forward * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position -= speed * transform.forward * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += speed * transform.right * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position -= speed * transform.right * Time.deltaTime;
                }

                float mx = Input.GetAxis("Mouse X");

                if (Mathf.Abs(mx) > 0.001f)
                {

                    transform.Rotate(0, mx, 0);

                }


            }
            if ((Input.GetKey(KeyCode.LeftShift) || (Input.GetKey(KeyCode.RightShift))) && stamina > 0 && lead == 0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
            {

                speed = 10.0f;

                stamina -= Time.deltaTime;

                if (stamina < 0)
                {
                    speed = 1.0f;

                    stamina = 0;
                }
            }
            else if (lead == 0)
            {
                speed = 5.0f;
                if (stamina < 5)
                {
                    stamina += Time.deltaTime;
                    if (stamina > 5)
                    {
                        stamina = 5;
                    }
                }
                if (stamina < 0)
                {
                    speed = 1.0f;

                    stamina = 0;
                }
            }




            if (this.transform.position.y < -10)
            {
                ResultTextScript.fall = 1;

                playerHPS.PlayerHP = 0;
            }


            /* 
                        if (lead == 1)
                        {
                            speed = 0;
                            GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 255);
                            lead = 2;
                            CancelInvoke();

                            Invoke(nameof(Leadcancel), 3.0f);
                        } */
            if (damage == 1)
            {

                GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
                damage = 2;
                PauseTextScript.Pause = 1;
                CancelInvoke();

                Invoke(nameof(Damagecancel), 0.5f);
            }


            if (playerHPS.PlayerHP <= 0)
            {
                restart = 1;

                PhotonNetwork.Instantiate("GoodByeParticle", transform.position, Quaternion.Euler(-90, 0, 0));
                Invoke(nameof(Restart), 0.1f);



            }

        }

    }
    /*    public void TagChangeDame()
       {
           GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 255);
           Debug.Log("Dame1");
       }
       public void TagChangeDame2()
       {

           Debug.Log("Dame2");
           Invoke(nameof(TagChangeDame3), 0.1f);
       }
       public void TagChangeDame3()
       {
           GetComponent<Renderer>().material.color = new Color32(28, 86, 236, 255);
           Debug.Log("Dame3");

       }
    */
    [PunRPC]
    private void RpcSendLead(int i)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == i)
        {
            GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 255);
        }
    }

    [PunRPC]
    private void RPCKill(int i)
    {


        if (PhotonNetwork.LocalPlayer.ActorNumber == i)
        {

            Invoke(nameof(kill), 0.1f);


        }

    }
    private void kill()
    {
        point++;
    }
    void OnTriggerEnter(Collider collider)
    {
        PlayerHPScript playerHPS;
        GameObject obj = GameObject.Find("PlayerObserver");
        playerHPS = obj.GetComponent<PlayerHPScript>();
        if (!photonView.IsMine)
        {
            return;
        }
        if (playerHPS.PlayerHP > 0)
        {
            return;
        }
        string objname = collider.gameObject.name;



    }
    public void Killnum(int i, string s)
    {
        killnumber = i;
        killname = s;
    }

    void Restart()
    {
        if (restart == 1)
        {


            if (ResultTextScript.retire == 1)
            {

                photonView.RPC(nameof(RpcSendDfeated), RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, "retired!");
            }
            else if (ResultTextScript.fall == 1)
            {
                photonView.RPC(nameof(RpcSendDfeated), RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, "fell!");
            }
            else
            {
                photonView.RPC(nameof(RPCKill), RpcTarget.All, killnumber);
                photonView.RPC(nameof(RpcSendDfeated), RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, "was killed by " + killname);
            }
            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            playerHPS.PlayerHP = 10;
            stamina = 5.0f;
            FireScript.bulletnum = 40;
            point -= 1;
            lead = 0;
            damage = 0;
            PauseTextScript.Pause = 1;
            GetComponent<Renderer>().material.color = new Color32(28, 86, 236, 255);
            ResultTextScript.retire = 0;
            ResultTextScript.fall = 0;


            Vector3 posi = new Vector3(Random.Range(-20f, 20f), 50, Random.Range(-20f, 20f));
            this.transform.position = posi;
            PlayerHPScript.Live = 0;
        }
        restart = 0;
    }
    [PunRPC]
    private void RpcSendDfeated(string name, string chat)
    {
        ChatTextScript.chat[ChatTextScript.chatcount] = string.Format("{0} {1}", name, chat);

        ChatTextScript.chatcount++;
    }
    void Leadcancel()
    {
        if (!photonView.IsMine)
        {
            return;
        }


        if (photonView.IsMine)
        {
            lead = 0;
            speed = 5;
            GetComponent<Renderer>().material.color = new Color32(28, 86, 236, 255);

        }
    }
    void Damagecancel()
    {
        if (!photonView.IsMine)
        {
            return;
        }


        if (photonView.IsMine)
        {
            damage = 0;

            GetComponent<Renderer>().material.color = new Color32(28, 86, 236, 255);

        }
    }

}
