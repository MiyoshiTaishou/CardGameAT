using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    private CardManager cardManager;

    [SerializeField,Header("カードデータ")]
    private CardDataBase cardData;

    [SerializeField,Header("カード名")]
    private Text cardName;

    [SerializeField, Header("カードテキスト")]
    private Text cardText;

    [SerializeField, Header("カードコスト")]
    private Text cardCost;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponentInParent<CanvasGroup>();

        cardName.text = cardData.CardName;
        cardText.text = cardData.CardText;
        cardCost.text = cardData.cost.ToString();

        cardManager = GameObject.FindObjectOfType<CardManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ開始時の処理が必要ならここに記述

        //初期位置保存
        originalPosition = rectTransform.anchoredPosition;

        // 他のUIとの衝突を無視（半透明にする）
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ドラッグ中にマウス位置に追従
        if (canvas != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {       
        // ドラッグ終了時の処理が必要ならここに記述
        // ドロップエリア判定
        if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("DropArea"))
        {
            Debug.Log("ドロップ成功！指定エリアにドロップされました。");
            OnDropSuccess();
        }
        else
        {
            Debug.Log("ドロップ失敗。元の位置に戻します。");
            rectTransform.anchoredPosition = originalPosition;
        }

        // 元の透明度に戻し、レイキャストを有効化
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        cardManager.AddToGraveyard(this.cardData);
        Destroy(this.gameObject);
    }

    private void OnDropSuccess()
    {
        // ドロップ成功時の処理
        Debug.Log("ドロップ成功の処理を実行中...");
        cardManager.GenerateCards(2);

    }

    public void SetCardData(CardDataBase data)
    {
        cardData = data;

        // UIを更新
        cardName.text = cardData.CardName;
        cardText.text = cardData.CardText;
        cardCost.text = cardData.cost.ToString();
    }
}
