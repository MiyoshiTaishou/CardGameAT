using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

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

        cardName.text = cardData.CardName;
        cardText.text = cardData.CardText;
        cardCost.text = cardData.cost.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // �h���b�O�J�n���̏������K�v�Ȃ炱���ɋL�q
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
    }
}
