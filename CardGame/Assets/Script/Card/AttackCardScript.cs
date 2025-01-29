using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardScript : CardScript
{
    protected override void OnDropSuccess(GameObject dropTarget)
    {
        Debug.Log("�U���J�[�h�̌��ʔ����I�ΏۂɃ_���[�W��^����");
        dropTarget.GetComponent<CharStatus>().Damage(this.cardData.cardPoint);

        // �ꎞ�I�ȃI�u�W�F�N�g���쐬���ASE ���Đ�
        GameObject seObject = new GameObject("TempSE");
        AudioSource tempAudio = seObject.AddComponent<AudioSource>();
        tempAudio.clip = this.cardData.cardSE;
        tempAudio.Play();

        // SE �̍Đ����I�������폜
        Destroy(seObject, this.cardData.cardSE.length);

        // �J�[�h�𑦍��ɍ폜
        Destroy(this.gameObject);
    }

}
