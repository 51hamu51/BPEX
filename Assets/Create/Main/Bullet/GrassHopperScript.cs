using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GrassHopperScript : MonoBehaviourPunCallbacks
{
    private float deleteTime = 3.0f;

    void Start()
    {
        if (photonView.IsMine)
        {
            StartCoroutine(AutoDestroyCoroutine());
        }
    }

    // 時限削除用のコルーチン
    IEnumerator AutoDestroyCoroutine()
    {
        yield return new WaitForSeconds(deleteTime);
        // 時間が来たらネットワーク上から削除
        PhotonNetwork.Destroy(gameObject);
    }


    void Update()
    {



    }

}
