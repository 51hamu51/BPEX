using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeManager : MonoBehaviour
{
    public GameObject Gauges;
    public bool IsGaugeOn;
    void Start()
    {
        Gauges.SetActive(true);
        IsGaugeOn = true;
    }

    void Update()
    {
        if (PauseTextScript.Pause == 1 && !IsGaugeOn)
        {
            Gauges.SetActive(true);
            IsGaugeOn = true;
        }
        else if (PauseTextScript.Pause == 0 && IsGaugeOn)
        {
            Gauges.SetActive(false);
            IsGaugeOn = false;
        }
    }
}
