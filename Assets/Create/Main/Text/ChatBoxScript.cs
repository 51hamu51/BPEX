using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class ChatBoxScript : MonoBehaviourPunCallbacks
{
    TMP_InputField _inputField;


    public Text text;



    void Start()
    {
        _inputField = GameObject.Find("ChatBox").GetComponent<TMP_InputField>();

    }


    void Update()
    {

    }


    public void SendText()
    {
        string message = _inputField.text;

        photonView.RPC(nameof(RpcSendMessage), RpcTarget.All, PhotonNetwork.LocalPlayer.NickName, message);
        _inputField.text = "";
    }

    [PunRPC]
    private void RpcSendMessage(string name, string chat)
    {
        ChatTextScript.chat[ChatTextScript.chatcount] = string.Format("{0} : {1}", name, chat);
        ChatTextScript.chatcount++;
    }
}
