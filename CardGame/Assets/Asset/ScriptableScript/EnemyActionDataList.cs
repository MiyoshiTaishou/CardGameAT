using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENEMYACTIONTYPE
{
    ATTACK,
    DEF,
    BUFF
}

[System.Serializable]
public struct EnemyAction
{
    [Header("行動タイプ")]
    public ENEMYACTIONTYPE actionType;

    [Header("行動名")]
    public string actionName;

    [Header("行動の値")]
    public int actionValue;    
}

[CreateAssetMenu(fileName = "EneymActionList", menuName = "ScriptableObjects/EneymActionListAsset")]
public class EnemyActionDataList : ScriptableObject
{
    [SerializeField, Header("敵行動リスト")]
    public EnemyAction[] type;
}
