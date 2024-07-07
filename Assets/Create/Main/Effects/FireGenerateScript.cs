using UnityEngine;
using Photon.Pun;

public class ParticleScript : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Me")
        {


            PhotonNetwork.Instantiate("FireParticle", transform.position, Quaternion.Euler(-90, 0, 0));
        }
    }
}