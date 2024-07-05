using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTextScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Text;
    public int ButtonNum;

    void Start()
    {

    }


    void Update()
    {


        Text.text = string.Format("{0}", SettingTextScript.Bul[ButtonNum]);

    }
}
