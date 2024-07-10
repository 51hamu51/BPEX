using UnityEngine;
using Photon.Pun;

public class KogetuFireGenerateScript : MonoBehaviourPunCallbacks
{

    void OnTriggerEnter(Collider collider)
    {
        if (photonView.IsMine)
        {
            return;
        }
        if (collider.gameObject.tag == "Me")
        {


            PhotonNetwork.Instantiate("FireParticle", transform.position, Quaternion.Euler(-90, 0, 0));
        }
    }
}