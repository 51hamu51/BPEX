using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHPScript : MonoBehaviour
{
    public int PlayerHP;
    public static int Live = 0;
    public GameObject playerobj;

    public HPGauge hPGauge;

    void Start()
    {
        PlayerHP = 10;
    }


    void Update()
    {
        if (PlayerHP <= 0 && Live == 0)
        {
            Live = 1;
            /* SceneManager.LoadScene("ResultScene"); */
        }
    }

    /// <summary>
    /// HPを減らす
    /// </summary>
    /// <param name="x">減らす量</param>
    public void Damage(int x)
    {
        PlayerHP -= x;
        hPGauge.HPReflect();
    }

    /// <summary>
    /// HPを指定の値にする
    /// </summary>
    /// <returns></returns>
    public void SetHP(int x)
    {
        PlayerHP = x;
        hPGauge.HPReflect();
    }

    /// <summary>
    /// HPの値を返す
    /// </summary>
    /// <returns></returns>
    public int GetHP()
    {
        return PlayerHP;
    }
}
