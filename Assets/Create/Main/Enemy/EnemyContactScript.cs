using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContactScript : MonoBehaviour
{
    public int contact;

    void Start()
    {
        contact = 0;
    }


    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Chameleon") || collision.gameObject.CompareTag("PlayerParts"))
        {
            contact = 1;
            Invoke("Rotate", 0.5f);
        }


    }
    private void Rotate()
    {
        contact = 0;
    }
}
