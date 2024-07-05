using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerNameTextScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI Text;

    void Start()
    {

    }


    void Update()
    {
        if (PauseTextScript.Pause == 0)
        {
            Text.text = string.Format("");
        }
        else
        {

            Text.text = string.Format("{0}", PhotonNetwork.LocalPlayer.NickName);

        }
    }
}
