using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireScript : MonoBehaviour
{

    private float FireTime = 1.0f;
    private float TimeCount = 0.0f;

    [SerializeField]
    private Transform firingPoint;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float speed = 30f;

    void Start()
    {

    }


    void Update()
    {




        TimeCount += Time.deltaTime;
        if (TimeCount > FireTime)
        {

            GameObject bullets = Instantiate(bullet) as GameObject;
            Vector3 force;
            force = this.gameObject.transform.forward * speed;
            bullets.GetComponent<Rigidbody>().AddForce(force);
            bullets.transform.position = firingPoint.position;

            TimeCount = 0;
            FireTime = Random.Range(0.5f, 1.0f);
        }



    }


}
