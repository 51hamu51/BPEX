using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class EnemyTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;



    void Start()
    {

    }

    void Update()
    {
        EnemyHPScript EnemyHPS;
        GameObject obj = GameObject.Find("EnemyObserver");
        EnemyHPS = obj.GetComponent<EnemyHPScript>();
        Text.text = string.Format("{0} / 10", EnemyHPS.EnemyHP);


    }
}