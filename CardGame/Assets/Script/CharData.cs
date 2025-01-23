using UnityEngine;

// CreateAssetMenu�������g�p���邱�Ƃ�`Assets > Create > ScriptableObjects > CreasteEnemyParamAsset`�Ƃ������ڂ��\�������
// ����������Ƃ���`EnemyParamAsset`��`Data`�Ƃ������O�ŃA�Z�b�g�������assets�t�H���_�ɓ���
[CreateAssetMenu(fileName = "NewCharData", menuName = "ScriptableObjects/CharDataAsset")]
public class CharData : ScriptableObject
{

    // private�ł�[SerializeField]�����邱�Ƃ�Inspector�Ŋm�F�ł���悤�ɂȂ�܂��B
    [SerializeField]
    public string Name = "��������";
    [SerializeField]
    public int MaxHP = 100;
    [SerializeField]
    public int MaxMP = 3;
    [SerializeField]
    public int DownPoint = 3;
    
}
