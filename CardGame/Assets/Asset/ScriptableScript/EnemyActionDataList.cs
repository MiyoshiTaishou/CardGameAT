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
    [Header("�s���^�C�v")]
    public ENEMYACTIONTYPE actionType;

    [Header("�s����")]
    public string actionName;

    [Header("�s���̒l")]
    public int actionValue;    
}

[CreateAssetMenu(fileName = "EneymActionList", menuName = "ScriptableObjects/EneymActionListAsset")]
public class EnemyActionDataList : ScriptableObject
{
    [SerializeField, Header("�G�s�����X�g")]
    public EnemyAction[] type;
}
