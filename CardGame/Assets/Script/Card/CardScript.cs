using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class CardScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    protected RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    protected CardManager cardManager;
    protected AudioSource audioSource;

    [SerializeField, Header("カードデータ")]
    protected CardDataBase cardData;

    [SerializeField, Header("カード名")]
    protected Text cardName;

    [SerializeField, Header("カードテキスト")]
    protected Text cardText;

    [SerializeField, Header("カードコスト")]
    protected Text cardCost;

    protected virtual void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponentInParent<CanvasGroup>();

        cardName.text = cardData.CardName;
        cardText.text = cardData.CardText;
        cardCost.text = cardData.cost.ToString();

        cardManager = GameObject.FindObjectOfType<CardManager>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.alpha = 0.6f;
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
        if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("DropArea"))
        {
            Debug.Log("ドロップ成功！");
            OnDropSuccess(eventData.pointerEnter);
        }
        else
        {
            Debug.Log("ドロップ失敗。元の位置に戻します。");
            rectTransform.anchoredPosition = originalPosition;
        }

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        cardManager.AddToGraveyard(this.cardData);
        Destroy(this.gameObject);
    }

    // 派生クラスで処理を変更できるようにする
    protected abstract void OnDropSuccess(GameObject dropTarget);

    public void SetCardData(CardDataBase data)
    {
        cardData = data;
        cardName.text = cardData.CardName;
        cardText.text = cardData.CardText;
        cardCost.text = cardData.cost.ToString();        
    }
}
