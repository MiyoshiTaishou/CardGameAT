using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

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

        cardName.text = cardData.CardName;
        cardText.text = cardData.CardText;
        cardCost.text = cardData.cost.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // ドラッグ開始時の処理が必要ならここに記述
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
    }
}
