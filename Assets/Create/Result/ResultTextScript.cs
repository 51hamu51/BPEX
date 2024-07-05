using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultTextScript : MonoBehaviour
{
    public static int score1 = 0;
    public static int score2 = 0;
    public static int score3 = 0;
    public static int score4 = 0;
    public static int RankedIn = 0;
    public static int fall;
    public static int retire;

    [SerializeField]
    private TextMeshProUGUI Text;


    void Start()
    {
        if (retire == 1)
        {
            Text.text = string.Format("    retire ... \nYour score is {0}", EnemyChangeScript.Point);
            retire = 0;
            PauseTextScript.Pause = 1;
        }
        else if (fall == 1)
        {
            Text.text = string.Format("     fall  ... \nYour score is {0}", EnemyChangeScript.Point);
            fall = 0;
        }
        else
        {
            Text.text = string.Format("    defeat ... \nYour score is {0}", EnemyChangeScript.Point);
        }
        Rank();
    }

    void Rank()
    {
        if (EnemyChangeScript.Point > score1)
        {

            score4 = score3;

            score3 = score2;

            score2 = score1;

            score1 = EnemyChangeScript.Point;

            EnemyChangeScript.Point = 0;
            RankedIn = 1;
        }
        else if (EnemyChangeScript.Point > score2)
        {

            score4 = score3;
            score3 = score2;
            score2 = EnemyChangeScript.Point;
            EnemyChangeScript.Point = 0;
            RankedIn = 1;
        }
        else if (EnemyChangeScript.Point > score3)
        {
            score4 = score3;
            score3 = EnemyChangeScript.Point;
            EnemyChangeScript.Point = 0;
            RankedIn = 1;
        }
        else if (EnemyChangeScript.Point > score4)
        {
            score4 = EnemyChangeScript.Point;
            EnemyChangeScript.Point = 0;
            RankedIn = 1;
        }
        else
        {

            EnemyChangeScript.Point = 0;
        }
    }
    void Update()
    {

    }
}
