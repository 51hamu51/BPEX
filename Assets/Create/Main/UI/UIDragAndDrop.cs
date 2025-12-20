using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    public ButtonManeScript buttonManeScript;

    /// <summary>
    /// 元の位置を保持
    /// </summary>
    public Vector2 startPos;

    /// <summary>
    /// Dropが成功したか
    /// </summary>
    public bool isDropped;

    /// <summary>
    /// 元のヒエラルキー順
    /// </summary>
    private int originalSiblingIndex;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canvasGroup != null)
        {
            startPos = rectTransform.anchoredPosition;
            isDropped = false;

            //元の描画順を保持して、最前面に持ってくる
            originalSiblingIndex = rectTransform.GetSiblingIndex();
            rectTransform.SetAsLastSibling();

            canvasGroup.blocksRaycasts = false; // ドラッグ中にレイキャストを無効にする

            buttonManeScript.DragStart(GetComponent<ButtonScript>().ButtonNum);
        }
    }

    /// <summary>
    /// ほかのボタンのドラッグが開始された
    /// </summary>
    public void OtherBeginDrag()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = true; // レイキャストを有効に戻す

            if (!isDropped)
            {
                ResetPos();
            }

            rectTransform.SetSiblingIndex(originalSiblingIndex);//元の描画順に戻す
        }

        buttonManeScript.DragFinish();

    }

    /// <summary>
    /// ほかのボタンがドロップされた
    /// </summary>
    public void OtherFinishDrag()
    {
        canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// 初期位置に戻す
    /// </summary>
    public void ResetPos()
    {
        rectTransform.anchoredPosition = startPos;
    }
}