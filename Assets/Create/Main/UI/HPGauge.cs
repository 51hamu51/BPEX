using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    [SerializeField] private Image gauge;
    void Start()
    {

    }

    void Update()
    {
        HPReflect();
    }

    private void HPReflect()
    {
        PlayerHPScript playerHPS;
        GameObject obj = GameObject.Find("PlayerObserver");
        playerHPS = obj.GetComponent<PlayerHPScript>();
        gauge.fillAmount = (float)playerHPS.PlayerHP / 10;
    }
}
