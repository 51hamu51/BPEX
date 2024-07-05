using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHPScript : MonoBehaviour
{
    public int PlayerHP;
    public static int Live = 0;
    public GameObject playerobj;

    void Start()
    {

        PlayerHP = 10;

    }


    void Update()
    {


        if (PlayerHP <= 0 && Live == 0)
        {
            Live = 1;
            /* SceneManager.LoadScene("ResultScene"); */

        }

    }
}
