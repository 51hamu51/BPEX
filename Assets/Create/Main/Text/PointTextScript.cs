using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PointTextScript : MonoBehaviour
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
            Text.text = string.Format("<alpha=#33>Point : {0}", PlayerScript.point);
        }
    }
}
