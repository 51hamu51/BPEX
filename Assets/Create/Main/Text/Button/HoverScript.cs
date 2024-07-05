using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    [SerializeField] GameObject Button;

    void Start()
    {

    }


    void Update()
    {

    }
    public void PointerEnter()
    {
        ButtonScript Bs;
        Bs = Button.GetComponent<ButtonScript>();


        DetailTextScript.DetailNum = Bs.ButtonNum;
    }
    public void PointerExit()
    {

        DetailTextScript.DetailNum = -1;
    }
}
