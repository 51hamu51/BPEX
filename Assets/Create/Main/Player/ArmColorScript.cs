using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ArmColorScript : MonoBehaviourPunCallbacks
{
    private GameObject obj;
    private Color defaultcolor;

    void Start()
    {
        obj = this.gameObject;
        defaultcolor = obj.GetComponent<Renderer>().material.color;
    }


    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }



        PlayerHPScript playerHPS;
        GameObject obj3 = GameObject.Find("PlayerObserver");
        playerHPS = obj3.GetComponent<PlayerHPScript>();




        if (FireScript.chameleonC == 1)
        {
            defaultcolor.a = 0.3f;
            GetComponent<Renderer>().material.color = defaultcolor;
            gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
        }
        else if (PlayerScript.lead != 0)
        {
            GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 255);
        }
        else if (PlayerScript.damage != 0)
        {
            GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 255);
        }
        else
        {
            defaultcolor.a = 1.0f;
            GetComponent<Renderer>().material.color = defaultcolor;
            gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
        }
    }
}
