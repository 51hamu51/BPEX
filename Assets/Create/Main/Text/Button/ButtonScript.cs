using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int ButtonNum = 0;

    void Start()
    {

    }

    void Update()
    {

    }
    public void Onclick()
    {
        if (ChangeTextScript.X == -1)
        {
            ChangeTextScript.X = ButtonNum;
        }
        else if (ChangeTextScript.Y == -1)
        {
            ChangeTextScript.Y = ButtonNum;
        }
    }


}
