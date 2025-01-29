using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardScript : CardScript
{
    protected override void OnDropSuccess(GameObject dropTarget)
    {
        Debug.Log("攻撃カードの効果発動！対象にダメージを与える");
        dropTarget.GetComponent<CharStatus>().Damage(this.cardData.cardPoint);

        // 一時的なオブジェクトを作成し、SE を再生
        GameObject seObject = new GameObject("TempSE");
        AudioSource tempAudio = seObject.AddComponent<AudioSource>();
        tempAudio.clip = this.cardData.cardSE;
        tempAudio.Play();

        // SE の再生が終わったら削除
        Destroy(seObject, this.cardData.cardSE.length);

        // カードを即座に削除
        Destroy(this.gameObject);
    }

}
