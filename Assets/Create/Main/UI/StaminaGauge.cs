using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaGauge : MonoBehaviour
{
    [SerializeField] private Image gauge;
    void Start()
    {

    }

    void Update()
    {
        StaminaReflect();
    }

    private void StaminaReflect()
    {
        gauge.fillAmount = PlayerScript.stamina * 1000 / 5000;
    }
}
