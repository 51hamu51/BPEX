using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MessageTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    void Start()
    {

    }


    void Update()
    {
        EnemyChangeScript EnemyS;
        GameObject obj = GameObject.Find("EnemyObject");
        EnemyS = obj.GetComponent<EnemyChangeScript>();
        if (PauseTextScript.Pause == 0)
        {
            Text.text = string.Format("");
        }
        else if (EnemyS.Me == 1)
        {
            Text.text = string.Format("Destroyed!!");
        }
        else
        {
            Text.text = string.Format("");
        }


    }
}
