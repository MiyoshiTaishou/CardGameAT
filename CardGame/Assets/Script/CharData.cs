using UnityEngine;

// CreateAssetMenu属性を使用することで`Assets > Create > ScriptableObjects > CreasteEnemyParamAsset`という項目が表示される
// それを押すとこの`EnemyParamAsset`が`Data`という名前でアセット化されてassetsフォルダに入る
[CreateAssetMenu(fileName = "NewCharData", menuName = "ScriptableObjects/CharDataAsset")]
public class CharData : ScriptableObject
{

    // privateでも[SerializeField]をつけることでInspectorで確認できるようになります。
    [SerializeField]
    public string Name = "おじさん";
    [SerializeField]
    public int MaxHP = 100;
    [SerializeField]
    public int MaxMP = 3;
    [SerializeField]
    public int DownPoint = 3;
    
}
