using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PauseTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public static int Pause = 1;

    void Start()
    {

    }


    void Update()
    {
        if (Pause == 0)
        {
            Text.text = string.Format("PAUSE");

        }
        else if (Pause == 1)
        {
            Text.text = string.Format("");
        }
    }
}
