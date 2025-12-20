using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBackGround : MonoBehaviour, IDropHandler
{
    public int backNum;

    public ButtonManeScript buttonManeScript;

    public void OnDrop(PointerEventData eventData)
    {


        GameObject droppedObj = eventData.pointerDrag;

        if (droppedObj == null)//入れ替わりが起きない場所でドロップ
        {
            buttonManeScript.ChangeCheck();
            return;
        }

        ButtonScript droppedButton = droppedObj.GetComponent<ButtonScript>();
        UIDragAndDrop drag = droppedObj.GetComponent<UIDragAndDrop>();
        if (droppedButton == null || drag == null) return;

        drag.isDropped = true;

        // この背景に元からいたボタン
        GameObject targetObj = buttonManeScript.SearchNumButton(backNum);
        if (targetObj == null) return;

        ButtonScript targetButton = targetObj.GetComponent<ButtonScript>();

        // === 座標保存 ===
        Vector2 droppedStartPos = drag.startPos;
        Vector2 targetPos = GetComponent<RectTransform>().anchoredPosition;

        // === 位置入れ替え ===
        droppedObj.GetComponent<RectTransform>().anchoredPosition = targetPos;
        targetObj.GetComponent<RectTransform>().anchoredPosition = droppedStartPos;

        // === ButtonNum（＝現在地）のスワップ ===
        int a = droppedButton.ButtonNum; // 元の場所
        int b = targetButton.ButtonNum;  // この背景
        droppedButton.ButtonNum = b;
        targetButton.ButtonNum = a;

        // === Bul 配列のスワップ（同じ index） ===
        var tmp = SettingTextScript.Bul[a];
        SettingTextScript.Bul[a] = SettingTextScript.Bul[b];
        SettingTextScript.Bul[b] = tmp;

        buttonManeScript.IsDragging = false;
        buttonManeScript.ChangeCheck();
    }
}
