using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardScript : CardScript
{    
    protected override void OnDropSuccess(GameObject dropTarget)
    {
        Debug.Log("�U���J�[�h�̌��ʔ����I�ΏۂɃ_���[�W��^����");

        dropTarget.GetComponent<CharStatus>().Damage(this.cardData.cardPoint);
    }
}
