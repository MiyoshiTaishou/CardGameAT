using UnityEngine;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    [SerializeField, Header("カードのプレハブ")]
    private GameObject cardPrefab;

    [SerializeField, Header("カードの生成先")]
    private Transform cardParent;

    [SerializeField, Header("カードデータのリスト")]
    private List<CardDataBase> cardDataList = new List<CardDataBase>();

    [SerializeField, Header("墓地のカードデータリスト")]
    private List<CardDataBase> graveyardList = new List<CardDataBase>();

    /// <summary>
    /// 指定した数だけカードを生成する
    /// </summary>
    /// <param name="count">生成するカードの数</param>
    public void GenerateCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // カードデータリストが空の場合、墓地からデータを戻す
            if (cardDataList.Count == 0)
            {
                if (graveyardList.Count > 0)
                {
                    Debug.Log("カードデータリストが空です。墓地からデータを戻します。");
                    RefillCardDataFromGraveyard();
                }
                else
                {
                    Debug.LogWarning("カードデータリストも墓地も空です。生成できません。");
                    return;
                }
            }

            // カードデータの取得（リストの先頭から取得）
            CardDataBase cardData = cardDataList[0];

            // カードを生成
            GameObject cardObject = Instantiate(cardPrefab, cardParent);

            // カードスクリプトにデータを渡す
            CardScript cardScript = cardObject.GetComponent<CardScript>();
            if (cardScript != null)
            {
                cardScript.SetCardData(cardData);
            }

            // リストから生成済みのカードデータを削除
            cardDataList.RemoveAt(0);
        }
    }

    /// <summary>
    /// 墓地のリストにカードを追加する
    /// </summary>
    /// <param name="cardData">追加するカードデータ</param>
    public void AddToGraveyard(CardDataBase cardData)
    {
        if (cardData != null)
        {
            graveyardList.Add(cardData);
            Debug.Log($"カード「{cardData.CardName}」を墓地に追加しました。");
        }
        else
        {
            Debug.LogWarning("追加しようとしたカードデータがnullです。");
        }
    }

    /// <summary>
    /// 墓地のデータを全てcardDataListに戻し、墓地を空にする
    /// </summary>
    private void RefillCardDataFromGraveyard()
    {
        if (graveyardList.Count > 0)
        {
            cardDataList.AddRange(graveyardList);
            graveyardList.Clear();
            Debug.Log("墓地のデータをcardDataListに戻しました。");
        }
        else
        {
            Debug.LogWarning("墓地が空です。何も戻せませんでした。");
        }
    }
}
