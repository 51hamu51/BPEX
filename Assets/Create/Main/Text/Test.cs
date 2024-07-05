using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Test : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI Text;

    void Start()
    {

    }


    void Update()
    {
        int i;
        Text.text = string.Format("");
        for (i = 0; i < 10; i++)
        {

            Text.text += string.Format("{0}:{1}\n", i, MemberScript.Point[i]);

        }
    }
}
