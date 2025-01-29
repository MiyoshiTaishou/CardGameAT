using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardScript : CardScript
{    
    protected override void OnDropSuccess(GameObject dropTarget)
    {
        Debug.Log("攻撃カードの効果発動！対象にダメージを与える");

        dropTarget.GetComponent<CharStatus>().Damage(this.cardData.cardPoint);
    }
}
