using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletGauge : MonoBehaviour
{
    [SerializeField] private Image gauge;
    void Start()
    {

    }

    void Update()
    {
        BulletReflect();
    }

    private void BulletReflect()
    {
        gauge.fillAmount = (float)FireScript.bulletnum / 40 * 0.8f + 0.2f;
    }
}
