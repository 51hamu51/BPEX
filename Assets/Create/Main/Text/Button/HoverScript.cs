using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    [SerializeField] GameObject Button;

    public ButtonManeScript buttonManeScript;

    /// <summary>
    /// 手が開いているカーソル
    /// </summary>
    public Texture2D openCursor;

    /// <summary>
    /// カーソル画像を変えた時のhotSpot
    /// </summary>
    private Vector2 hotSpot;

    void Start()
    {
        hotSpot = new Vector2(
            openCursor.width / 2,
            openCursor.height / 2
        );
    }


    void Update()
    {

    }
    public void PointerEnter()
    {
        if (buttonManeScript.IsDragging)
        {
            return;
        }

        ButtonScript Bs;
        Bs = Button.GetComponent<ButtonScript>();


        DetailTextScript.DetailNum = Bs.ButtonNum;

        Cursor.SetCursor(openCursor, hotSpot, CursorMode.Auto);//カーソルの変更
    }
    public void PointerExit()
    {
        if (buttonManeScript.IsDragging)
        {
            return;
        }
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);//カーソルをデフォルトに戻す

        DetailTextScript.DetailNum = -1;
    }
}
