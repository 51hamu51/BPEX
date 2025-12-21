using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManeScript : MonoBehaviour
{

    [SerializeField] GameObject[] Buttons;


    [SerializeField] GameObject[] ButtonBacks;


    [SerializeField] GameObject Retire;
    [SerializeField] GameObject[] ButtonTexts;

    /// <summary>
    /// ボタン移動中かどうか
    /// </summary>
    public bool IsDragging;

    /// <summary>
    /// ドラッグしているボタン
    /// </summary>
    public GameObject movingButton;

    void Start()
    {
        IsDragging = false;
    }

    void Update()
    {
        bool isActive = (PauseTextScript.Pause == 0);

        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].SetActive(isActive);
            ButtonBacks[i].SetActive(isActive);
        }

        Retire.SetActive(isActive);
    }

    public void DragStart(int x)
    {
        IsDragging = true;
        movingButton = SearchNumButton(x);
        foreach (var button in Buttons)
        {
            button.GetComponent<UIDragAndDrop>().OtherBeginDrag();
        }
    }

    public void DragFinish()
    {
        IsDragging = false;
        foreach (var button in Buttons)
        {
            button.GetComponent<UIDragAndDrop>().OtherFinishDrag();
        }
    }

    /// <summary>
    /// buttomNumがxであるボタンを返す
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public GameObject SearchNumButton(int x)
    {
        foreach (var btn in Buttons)
        {
            if (btn.GetComponent<ButtonScript>().ButtonNum == x)
                return btn;
        }
        return null;
    }

    /// <summary>
    /// 場所を入れ替えるのか、元の位置に戻すのかの判断
    /// </summary>
    public void ChangeCheck()
    {
        if (IsDragging)
        {
            movingButton.GetComponent<UIDragAndDrop>().ResetPos();

        }
    }
}
