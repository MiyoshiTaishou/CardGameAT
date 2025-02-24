using UnityEngine;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    [SerializeField, Header("�J�[�h�̃v���n�u")]
    private GameObject cardPrefab;

    [SerializeField, Header("�J�[�h�̐�����i��D�G���A�j")]
    private Transform handCanvas;

    [SerializeField, Header("�J�[�h�f�[�^�̃��X�g�i�f�b�L�j")]
    private List<CardDataBase> cardDataList = new List<CardDataBase>();

    [SerializeField, Header("��n�̃J�[�h�f�[�^���X�g")]
    private List<CardDataBase> graveyardList = new List<CardDataBase>();

    [SerializeField, Header("���݂̎�D�i�Q�[���I�u�W�F�N�g���X�g�j")]
    private List<GameObject> handCards = new List<GameObject>();

    /// <summary>
    /// �w�肵���������J�[�h�𐶐�����
    /// </summary>
    /// <param name="count">��������J�[�h�̐�</param>
    public void GenerateCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (cardDataList.Count == 0)
            {
                if (graveyardList.Count > 0)
                {
                    Debug.Log("�J�[�h�f�[�^���X�g����ł��B��n����f�[�^��߂��܂��B");
                    RefillCardDataFromGraveyard();
                }
                else
                {
                    Debug.LogWarning("�J�[�h�f�[�^���X�g����n����ł��B�����ł��܂���B");
                    return;
                }
            }

            CardDataBase cardData = cardDataList[0];

            // �J�[�h����D�iHandCanvas�j�ɐ���
            GameObject cardObject = Instantiate(cardPrefab, handCanvas);

            // �J�[�h�̎�ނɉ����ăX�N���v�g��t���ւ�
            CardScript cardScript = null;
            switch (cardData.type)
            {
                case CARDTYPE.ATTACK:
                    cardScript = cardObject.AddComponent<AttackCardScript>();
                    break;
                case CARDTYPE.BUFF:
                    cardScript = cardObject.AddComponent<DefCardScript>();
                    break;
                default:
                    cardScript = cardObject.AddComponent<CardScript>(); // �f�t�H���g�i��{�J�[�h�j
                    break;
            }

            if (cardScript != null)
            {
                cardScript.SetCardData(cardData);
            }

            cardDataList.RemoveAt(0);
        }
    }


    /// <summary>
    /// ��n�̃��X�g�ɃJ�[�h��ǉ�����
    /// </summary>
    /// <param name="cardData">�ǉ�����J�[�h�f�[�^</param>
    public void AddToGraveyard(CardDataBase cardData)
    {
        if (cardData != null)
        {
            graveyardList.Add(cardData);
            Debug.Log($"�J�[�h�u{cardData.CardName}�v���n�ɒǉ����܂����B");
        }
        else
        {
            Debug.LogWarning("�ǉ����悤�Ƃ����J�[�h�f�[�^��null�ł��B");
        }
    }

    /// <summary>
    /// ��n�̃f�[�^��S��cardDataList�ɖ߂��A��n����ɂ���
    /// </summary>
    private void RefillCardDataFromGraveyard()
    {
        if (graveyardList.Count > 0)
        {
            cardDataList.AddRange(graveyardList);
            graveyardList.Clear();
            Debug.Log("��n�̃f�[�^��cardDataList�ɖ߂��܂����B");
        }
        else
        {
            Debug.LogWarning("��n����ł��B�����߂��܂���ł����B");
        }
    }

    /// <summary>
    /// �w�肵���J�[�h����D����̂Ăĕ�n�֑���
    /// </summary>
    /// <param name="cardObject">�̂Ă�J�[�h�̃Q�[���I�u�W�F�N�g</param>
    public void DiscardCard(GameObject cardObject)
    {
        if (handCards.Contains(cardObject))
        {
            CardScript cardScript = cardObject.GetComponent<CardScript>();
            if (cardScript != null)
            {
                // �J�[�h�f�[�^���n�֒ǉ�
                graveyardList.Add(cardScript.GetCardData());
                Debug.Log($"�J�[�h�u{cardScript.GetCardData().CardName}�v���n�Ɏ̂Ă܂����B");
            }

            // ��D���X�g����폜
            handCards.Remove(cardObject);

            // �J�[�h�I�u�W�F�N�g���폜
            Destroy(cardObject);
        }
        else
        {
            Debug.LogWarning("�w�肳�ꂽ�J�[�h�͎�D�ɑ��݂��܂���B");
        }
    }

    /// <summary>
    /// ���ׂĂ̎�D���̂Ă�i��n�֑���j
    /// </summary>
    public void DiscardAllCards()
    {
        if (handCards.Count == 0)
        {
            Debug.LogWarning("��D����ł��B�̂Ă�J�[�h������܂���B");
            return;
        }

        // ��D�̃J�[�h�����ׂĕ�n�֑���
        foreach (var cardObject in new List<GameObject>(handCards))
        {
            DiscardCard(cardObject);
        }

        Debug.Log("���ׂĂ̎�D���n�Ɏ̂Ă܂����B");
    }

    /// <summary>
    /// ���݂̎�D���擾����
    /// </summary>
    /// <returns>��D�̃J�[�h�I�u�W�F�N�g�̃��X�g</returns>
    public List<GameObject> GetHandCards()
    {
        return new List<GameObject>(handCards);
    }
}
