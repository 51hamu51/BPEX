using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class NameChangeScript : MonoBehaviourPunCallbacks
{
    TMP_InputField _inputField;


    public Text text;



    void Start()
    {
        _inputField = GameObject.Find("NameChangeBox").GetComponent<TMP_InputField>();

    }


    void Update()
    {

    }


    public void DisplayText()
    {
        string name = _inputField.text;

        PhotonNetwork.LocalPlayer.NickName = name;
        _inputField.text = "";
    }


}
