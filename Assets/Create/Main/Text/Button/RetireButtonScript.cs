using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetireButtonScript : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }
    public void Onclick()
    {
        PlayerHPScript playerHPS;
        GameObject obj = GameObject.Find("PlayerObserver");
        playerHPS = obj.GetComponent<PlayerHPScript>();
        ResultTextScript.retire = 1;
        playerHPS.PlayerHP = 0;
        PauseTextScript.Pause = 1;
    }
}
