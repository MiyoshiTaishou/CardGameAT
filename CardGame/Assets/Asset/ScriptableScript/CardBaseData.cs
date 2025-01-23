using UnityEngine;

public enum CARDTYPE
{
    ATTACK,
    BUFF,
    DEBUFF,
};


// CreateAssetMenu�������g�p���邱�Ƃ�`Assets > Create > ScriptableObjects > CreasteEnemyParamAsset`�Ƃ������ڂ��\�������
// ����������Ƃ���`EnemyParamAsset`��`Data`�Ƃ������O�ŃA�Z�b�g�������assets�t�H���_�ɓ���
[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardDataAsset")]
public class CardDataBase : ScriptableObject
{
    [SerializeField, Header("�J�[�h�^�C�v")]
    public CARDTYPE type;

    [SerializeField,Header("�J�[�h��")]
    public string CardName = "�������@";

    [SerializeField, Header("�R�X�g"), Range(0, 5)]
    public int cost;

    [SerializeField, Header("�J�[�h�e�L�X�g")]
    public string CardText = "����͏������@��";

    [SerializeField, Header("�J�[�h�̌��ʂ̒l")]
    public int cardPoint;
}