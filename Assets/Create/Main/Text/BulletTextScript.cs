using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    void Start()
    {

    }


    void Update()
    {




        if (PauseTextScript.Pause == 0)
        {
            Text.text = string.Format("");
        }
        else
        {
            Text.text = string.Format("<alpha=#33>Bullet : {0} / 40", FireScript.bulletnum);
        }
    }
}
