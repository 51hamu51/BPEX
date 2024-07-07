using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManeScript : MonoBehaviour
{
    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;
    [SerializeField] GameObject Button3;
    [SerializeField] GameObject Button4;
    [SerializeField] GameObject Button5;
    [SerializeField] GameObject Button6;
    [SerializeField] GameObject Button7;
    [SerializeField] GameObject Button8;
    [SerializeField] GameObject Button9;
    [SerializeField] GameObject Button10;
    /* [SerializeField] GameObject Button11;
    [SerializeField] GameObject Button12; */
    [SerializeField] GameObject Retire;
    [SerializeField] GameObject Button1Text;
    [SerializeField] GameObject Button2Text;
    [SerializeField] GameObject Button3Text;
    [SerializeField] GameObject Button4Text;
    [SerializeField] GameObject Button5Text;
    [SerializeField] GameObject Button6Text;
    [SerializeField] GameObject Button7Text;
    [SerializeField] GameObject Button8Text;
    [SerializeField] GameObject Button9Text;
    [SerializeField] GameObject Button10Text;
    /*  [SerializeField] GameObject Button11Text;
     [SerializeField] GameObject Button12Text; */

    void Start()
    {
        ButtonScript B1s;
        B1s = Button1.GetComponent<ButtonScript>();
        B1s.ButtonNum = 0;
        ButtonScript B2s;
        B2s = Button2.GetComponent<ButtonScript>();
        B2s.ButtonNum = 1;
        ButtonScript B3s;
        B3s = Button3.GetComponent<ButtonScript>();
        B3s.ButtonNum = 2;
        ButtonScript B4s;
        B4s = Button4.GetComponent<ButtonScript>();
        B4s.ButtonNum = 3;
        ButtonScript B5s;
        B5s = Button5.GetComponent<ButtonScript>();
        B5s.ButtonNum = 4;
        ButtonScript B6s;
        B6s = Button6.GetComponent<ButtonScript>();
        B6s.ButtonNum = 5;
        ButtonScript B7s;
        B7s = Button7.GetComponent<ButtonScript>();
        B7s.ButtonNum = 6;
        ButtonScript B8s;
        B8s = Button8.GetComponent<ButtonScript>();
        B8s.ButtonNum = 7;
        ButtonScript B9s;
        B9s = Button9.GetComponent<ButtonScript>();
        B9s.ButtonNum = 8;
        ButtonScript B10s;
        B10s = Button10.GetComponent<ButtonScript>();
        B10s.ButtonNum = 9;
        /*  ButtonScript B11s;
         B11s = Button11.GetComponent<ButtonScript>();
         B11s.ButtonNum = 10;
         ButtonScript B12s;
         B12s = Button12.GetComponent<ButtonScript>();
         B12s.ButtonNum = 11; */

        ButtonTextScript B1Ts;
        B1Ts = Button1Text.GetComponent<ButtonTextScript>();
        B1Ts.ButtonNum = 0;
        ButtonTextScript B2Ts;
        B2Ts = Button2Text.GetComponent<ButtonTextScript>();
        B2Ts.ButtonNum = 1;
        ButtonTextScript B3Ts;
        B3Ts = Button3Text.GetComponent<ButtonTextScript>();
        B3Ts.ButtonNum = 2;
        ButtonTextScript B4Ts;
        B4Ts = Button4Text.GetComponent<ButtonTextScript>();
        B4Ts.ButtonNum = 3;
        ButtonTextScript B5Ts;
        B5Ts = Button5Text.GetComponent<ButtonTextScript>();
        B5Ts.ButtonNum = 4;
        ButtonTextScript B6Ts;
        B6Ts = Button6Text.GetComponent<ButtonTextScript>();
        B6Ts.ButtonNum = 5;
        ButtonTextScript B7Ts;
        B7Ts = Button7Text.GetComponent<ButtonTextScript>();
        B7Ts.ButtonNum = 6;
        ButtonTextScript B8Ts;
        B8Ts = Button8Text.GetComponent<ButtonTextScript>();
        B8Ts.ButtonNum = 7;
        ButtonTextScript B9Ts;
        B9Ts = Button9Text.GetComponent<ButtonTextScript>();
        B9Ts.ButtonNum = 8;
        ButtonTextScript B10Ts;
        B10Ts = Button10Text.GetComponent<ButtonTextScript>();
        B10Ts.ButtonNum = 9;
        /*  ButtonTextScript B11Ts;
         B11Ts = Button11Text.GetComponent<ButtonTextScript>();
         B11Ts.ButtonNum = 10;
         ButtonTextScript B12Ts;
         B12Ts = Button12Text.GetComponent<ButtonTextScript>();
         B12Ts.ButtonNum = 11; */
    }

    void Update()
    {
        if (PauseTextScript.Pause == 0)
        {
            Button1.SetActive(true);
            Button2.SetActive(true);
            Button3.SetActive(true);
            Button4.SetActive(true);
            Button5.SetActive(true);
            Button6.SetActive(true);
            Button7.SetActive(true);
            Button8.SetActive(true);
            Button9.SetActive(true);
            Button10.SetActive(true);
            /* Button11.SetActive(true);
            Button12.SetActive(true); */
            Retire.SetActive(true);



        }
        else if (PauseTextScript.Pause == 1)
        {
            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
            Button4.SetActive(false);
            Button5.SetActive(false);
            Button6.SetActive(false);
            Button7.SetActive(false);
            Button8.SetActive(false);
            Button9.SetActive(false);
            Button10.SetActive(false);
            /* Button11.SetActive(false);
            Button12.SetActive(false); */
            Retire.SetActive(false);
        }
    }
}
