using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;

    void Start()
    {

        Text.text = string.Format("Ranking\n1.  {0}  point\n2.  {1}  point\n3.  {2}  point\n4.  {3}  point\n", ResultTextScript.score1, ResultTextScript.score2, ResultTextScript.score3, ResultTextScript.score4);

    }


    void Update()
    {

    }
}
