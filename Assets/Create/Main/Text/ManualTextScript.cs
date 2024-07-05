using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ManualTextScript : MonoBehaviour
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
            Text.text = string.Format(" <alpha=#33>L click :shoot\nR click  :reload\n  C click  : spread\nWASD:move\n   QE  :lotate\n  shift :dash\n     Escape  :pause");
        }
    }
}
