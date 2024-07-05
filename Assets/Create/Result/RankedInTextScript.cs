using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankedInTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    void Start()
    {

    }
    void Update()
    {
        if (ResultTextScript.RankedIn == 1)
        {
            Text.text = string.Format("Your score ranked in!!");
            ResultTextScript.RankedIn = 0;
        }
    }
}
