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

    [SerializeField,Header("�J�[�h�f�[�^")]
    private CardDataBase cardData;

    [SerializeField,Header("�J�[�h��")]
    private Text cardName;

    [SerializeField, Header("�J�[�h�e�L�X�g")]
    private Text cardText;

    [SerializeField, Header("�J�[�h�R�X�g")]
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
        // �h���b�O�J�n���̏������K�v�Ȃ炱���ɋL�q

        //�����ʒu�ۑ�
        originalPosition = rectTransform.anchoredPosition;

        // ����UI�Ƃ̏Փ˂𖳎��i�������ɂ���j
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �h���b�O���Ƀ}�E�X�ʒu�ɒǏ]
        if (canvas != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {       
        // �h���b�O�I�����̏������K�v�Ȃ炱���ɋL�q
        // �h���b�v�G���A����
        if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("DropArea"))
        {
            Debug.Log("�h���b�v�����I�w��G���A�Ƀh���b�v����܂����B");
            OnDropSuccess();
        }
        else
        {
            Debug.Log("�h���b�v���s�B���̈ʒu�ɖ߂��܂��B");
            rectTransform.anchoredPosition = originalPosition;
        }

        // ���̓����x�ɖ߂��A���C�L���X�g��L����
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        cardManager.AddToGraveyard(this.cardData);
        Destroy(this.gameObject);
    }

    private void OnDropSuccess()
    {
        // �h���b�v�������̏���
        Debug.Log("�h���b�v�����̏��������s��...");
        cardManager.GenerateCards(2);

    }

    public void SetCardData(CardDataBase data)
    {
        cardData = data;

        // UI���X�V
        cardName.text = cardData.CardName;
        cardText.text = cardData.CardText;
        cardCost.text = cardData.cost.ToString();
    }
}
