using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ChatTextScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public static string[] chat = new string[200];

    public static int chatcount = 5;

    void Start()
    {

    }


    void Update()
    {
        int i;
        Text.text = string.Format("");
        for (i = chatcount - 5; i < chatcount; i++)
        {

            Text.text += string.Format("{0}\n", chat[i]);

        }
    }
}
