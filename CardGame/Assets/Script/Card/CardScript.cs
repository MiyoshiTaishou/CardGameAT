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
    protected Turn turnManager;
    protected AudioSource audioSource;

    [SerializeField, Header("�J�[�h�f�[�^")]
    protected CardDataBase cardData;

    [SerializeField, Header("�J�[�h��")]
    protected Text cardName;

    [SerializeField, Header("�J�[�h�e�L�X�g")]
    protected Text cardText;

    [SerializeField, Header("�J�[�h�R�X�g")]
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
        turnManager = GameObject.FindObjectOfType<Turn>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (turnManager.isPlayerTurn)
        {
            originalPosition = rectTransform.anchoredPosition;
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (turnManager.isPlayerTurn)
        {
            if (canvas != null)
            {
                rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (turnManager.isPlayerTurn)
        {
            if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("DropArea"))
            {
                Debug.Log("�h���b�v�����I");
                OnDropSuccess(eventData.pointerEnter);
                cardManager.AddToGraveyard(this.cardData);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("�h���b�v���s�B���̈ʒu�ɖ߂��܂��B");
                rectTransform.anchoredPosition = originalPosition;
            }

            canvasGroup.alpha = 1.0f;
            canvasGroup.blocksRaycasts = true;           
        }
    }

    // �h���N���X�ŏ�����ύX�ł���悤�ɂ���
    protected abstract void OnDropSuccess(GameObject dropTarget);

    public void SetCardData(CardDataBase data)
    {
        cardData = data;
        cardName.text = cardData.CardName;
        cardText.text = cardData.CardText;
        cardCost.text = cardData.cost.ToString();        
    }
}
