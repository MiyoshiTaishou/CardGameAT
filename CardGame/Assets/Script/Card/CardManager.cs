using UnityEngine;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    [SerializeField, Header("カードのプレハブ")]
    private GameObject cardPrefab;

    [SerializeField, Header("カードの生成先（手札エリア）")]
    private Transform handCanvas;

    [SerializeField, Header("カードデータのリスト（デッキ）")]
    private List<CardDataBase> cardDataList = new List<CardDataBase>();

    [SerializeField, Header("墓地のカードデータリスト")]
    private List<CardDataBase> graveyardList = new List<CardDataBase>();

    [SerializeField, Header("現在の手札（ゲームオブジェクトリスト）")]
    private List<GameObject> handCards = new List<GameObject>();

    /// <summary>
    /// 指定した数だけカードを生成する
    /// </summary>
    /// <param name="count">生成するカードの数</param>
    public void GenerateCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
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

            CardDataBase cardData = cardDataList[0];

            // カードを手札（HandCanvas）に生成
            GameObject cardObject = Instantiate(cardPrefab, handCanvas);

            // カードの種類に応じてスクリプトを付け替え
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
                    cardScript = cardObject.AddComponent<CardScript>(); // デフォルト（基本カード）
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

    /// <summary>
    /// 指定したカードを手札から捨てて墓地へ送る
    /// </summary>
    /// <param name="cardObject">捨てるカードのゲームオブジェクト</param>
    public void DiscardCard(GameObject cardObject)
    {
        if (handCards.Contains(cardObject))
        {
            CardScript cardScript = cardObject.GetComponent<CardScript>();
            if (cardScript != null)
            {
                // カードデータを墓地へ追加
                graveyardList.Add(cardScript.GetCardData());
                Debug.Log($"カード「{cardScript.GetCardData().CardName}」を墓地に捨てました。");
            }

            // 手札リストから削除
            handCards.Remove(cardObject);

            // カードオブジェクトを削除
            Destroy(cardObject);
        }
        else
        {
            Debug.LogWarning("指定されたカードは手札に存在しません。");
        }
    }

    /// <summary>
    /// すべての手札を捨てる（墓地へ送る）
    /// </summary>
    public void DiscardAllCards()
    {
        if (handCards.Count == 0)
        {
            Debug.LogWarning("手札が空です。捨てるカードがありません。");
            return;
        }

        // 手札のカードをすべて墓地へ送る
        foreach (var cardObject in new List<GameObject>(handCards))
        {
            DiscardCard(cardObject);
        }

        Debug.Log("すべての手札を墓地に捨てました。");
    }

    /// <summary>
    /// 現在の手札を取得する
    /// </summary>
    /// <returns>手札のカードオブジェクトのリスト</returns>
    public List<GameObject> GetHandCards()
    {
        return new List<GameObject>(handCards);
    }
}
