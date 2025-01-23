using UnityEngine;

public enum CARDTYPE
{
    ATTACK,
    BUFF,
    DEBUFF,
};


// CreateAssetMenu属性を使用することで`Assets > Create > ScriptableObjects > CreasteEnemyParamAsset`という項目が表示される
// それを押すとこの`EnemyParamAsset`が`Data`という名前でアセット化されてassetsフォルダに入る
[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardDataAsset")]
public class CardDataBase : ScriptableObject
{
    [SerializeField, Header("カードタイプ")]
    public CARDTYPE type;

    [SerializeField,Header("カード名")]
    public string CardName = "初級魔法";

    [SerializeField, Header("コスト"), Range(0, 5)]
    public int cost;

    [SerializeField, Header("カードテキスト")]
    public string CardText = "これは初級魔法だ";

    [SerializeField, Header("カードの効果の値")]
    public int cardPoint;
}