using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManagerScript : MonoBehaviour
{
    [SerializeField] GameObject NameChangeBox;
    [SerializeField] GameObject TriggerFrame;
    [SerializeField] GameObject ChatBox;

    void Start()
    {

    }


    void Update()
    {

        if (PauseTextScript.Pause == 1)
        {
            NameChangeBox.SetActive(false);
            TriggerFrame.SetActive(false);
            ChatBox.SetActive(false);

        }
        else
        {
            NameChangeBox.SetActive(true);
            TriggerFrame.SetActive(true);
            ChatBox.SetActive(true);

        }

    }
}
