using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoundScript : MonoBehaviour
{
    private GameObject player;
    private int speed = 15;
    private float deleteTime = 3.0f;

    void Start()
    {
        Destroy(gameObject, deleteTime);
        InvokeRepeating("Seach", 0, 1);
    }


    void Update()
    {

        this.transform.position += speed * this.transform.forward * Time.deltaTime;
    }
    void Seach()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            this.transform.LookAt(player.transform);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHPScript PlayerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            PlayerHPS = obj.GetComponent<PlayerHPScript>();
            PlayerHPS.PlayerHP -= 1;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Chameleon"))
        {
            PlayerHPScript playerHPS;
            GameObject obj = GameObject.Find("PlayerObserver");
            playerHPS = obj.GetComponent<PlayerHPScript>();
            playerHPS.PlayerHP -= 1;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Shield"))
        {

            Destroy(gameObject);
        }
    }
}
