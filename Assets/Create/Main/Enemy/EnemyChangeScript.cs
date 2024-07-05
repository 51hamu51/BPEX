using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyChangeScript : MonoBehaviour
{
    public GameObject[] EnemyArray;
    private int count;
    public GameObject enemyobj;
    float speed = 3.0f;
    public int lead = 0;
    public float ChangeTime = 0.1f;
    float TimeC;
    public int Ene = 1;
    public int En = 1;
    public static int Point = 0;
    private int Enenum = 0;

    public float EnemySpped = 3;
    public int Me = 0;
    private float MeTime = 1.0f;
    private float MeTimeC = 0.0f;
    private GameObject player;
    private Color defaultcolor;


    void Start()
    {

        EnemyHPScript EnemyHPS;
        GameObject obj = GameObject.Find("EnemyObserver");
        EnemyHPS = obj.GetComponent<EnemyHPScript>();
        EnemyHPS.EnemyHP = 10;



    }

    void Update()
    {
        EnemyChange();

        EnemyMove();

        if (lead == 0)
        {
            speed = 3;
            enemyobj.GetComponent<Renderer>().material.color = defaultcolor;
        }
        if (lead == 1)
        {
            speed = 0;
            enemyobj.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 255);
            lead = 2;
            CancelInvoke();

            Invoke(nameof(Leadcancel), 3.0f);
        }
    }

    void Leadcancel()
    {



        lead = 0;


    }
    private void EnemyChange()
    {
        Vector3 pos = new Vector3();
        pos.x = Random.Range(-20.0f, 20.0f);
        pos.y = 1.5f;
        pos.z = Random.Range(-20.0f, 20.0f);

        EnemyHPScript EnemyHPS;
        GameObject obj = GameObject.Find("EnemyObserver");
        EnemyHPS = obj.GetComponent<EnemyHPScript>();
        int rnd = Random.Range(0, 4);
        if (enemyobj == null)
        {
            Enenum = rnd;
            EnemyHPS.EnemyHP = 10;
            enemyobj = GameObject.Instantiate(EnemyArray[Enenum], pos, Quaternion.identity) as GameObject;

            defaultcolor = enemyobj.GetComponent<Renderer>().material.color;

        }

        if (EnemyHPS.EnemyHP <= 0)
        {
            Enenum = 0;
            lead = 0;
            Destroy(enemyobj);

            Point += 1;

            EnemyHPS.EnemyHP = 10;
            Me = 1;
            MeTimeC = 0;


        }
        MeTimeC += Time.deltaTime;
        if (MeTimeC > MeTime)
        {
            Me = 0;
            MeTimeC = 0;
        }
        if (enemyobj.transform.position.y < -10)
        {
            EnemyHPS.EnemyHP = 0;

        }


    }
    private void EnemyMove()
    {

        EnemyContactScript EnemyContactS;

        EnemyContactS = enemyobj.GetComponent<EnemyContactScript>();

        if (enemyobj != null)
        {
            TimeC += Time.deltaTime;
            enemyobj.transform.position += speed * enemyobj.transform.forward * Time.deltaTime;




            if (TimeC > ChangeTime)
            {
                /*敵が常にPlayerを向く*/
                player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    float dis = Vector3.Distance(player.transform.position, enemyobj.transform.position);
                    if (dis < 70 && EnemyContactS.contact == 0 && dis > 1.5)
                    {
                        Vector3 playerpos = player.transform.position;
                        playerpos.y = enemyobj.transform.position.y;
                        enemyobj.transform.LookAt(playerpos);
                        TimeC = 0;
                    }
                    else
                    {
                        RandomMove();
                    }


                }
                else
                {

                    RandomMove();


                }



            }
        }





    }
    private void RandomMove()
    {
        /*****敵がランダムに動く*****/
        /*他者のプログラムを参考にして自身で修正*/
        float x = Random.Range(-1, 2);
        if (x < -0.3)
        {
            Vector3 Cource = new Vector3(0, Random.Range(-180, -60), 0);
            enemyobj.transform.localRotation = Quaternion.Euler(Cource);

            TimeC = 0;
        }
        else if (x < 0.3)
        {
            Vector3 Cource = new Vector3(0, Random.Range(60, 180), 0);
            enemyobj.transform.localRotation = Quaternion.Euler(Cource);

            TimeC = 0;
        }
        else
        {
            Vector3 Cource = new Vector3(0, Random.Range(-60, 60), 0);
            enemyobj.transform.localRotation = Quaternion.Euler(Cource);

            TimeC = 0;
        }
    }
}
