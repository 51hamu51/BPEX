using UnityEngine;
using Photon.Pun;

public class FireGenerateScript : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        // 当たった相手が"Player"タグを持っていたら
        if (collider.gameObject.tag == "Me")
        {
            Debug.Log("me");

            PhotonNetwork.Instantiate("FireParticle", transform.position, Quaternion.Euler(-90, 0, 0));
        }
    }
}