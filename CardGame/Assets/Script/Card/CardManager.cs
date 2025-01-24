using UnityEngine;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    [SerializeField, Header("�J�[�h�̃v���n�u")]
    private GameObject cardPrefab;

    [SerializeField, Header("�J�[�h�̐�����")]
    private Transform cardParent;

    [SerializeField, Header("�J�[�h�f�[�^�̃��X�g")]
    private List<CardDataBase> cardDataList = new List<CardDataBase>();

    [SerializeField, Header("��n�̃J�[�h�f�[�^���X�g")]
    private List<CardDataBase> graveyardList = new List<CardDataBase>();

    /// <summary>
    /// �w�肵���������J�[�h�𐶐�����
    /// </summary>
    /// <param name="count">��������J�[�h�̐�</param>
    public void GenerateCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // �J�[�h�f�[�^���X�g����̏ꍇ�A��n����f�[�^��߂�
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

            // �J�[�h�f�[�^�̎擾�i���X�g�̐擪����擾�j
            CardDataBase cardData = cardDataList[0];

            // �J�[�h�𐶐�
            GameObject cardObject = Instantiate(cardPrefab, cardParent);

            // �J�[�h�X�N���v�g�Ƀf�[�^��n��
            CardScript cardScript = cardObject.GetComponent<CardScript>();
            if (cardScript != null)
            {
                cardScript.SetCardData(cardData);
            }

            // ���X�g���琶���ς݂̃J�[�h�f�[�^���폜
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
}
