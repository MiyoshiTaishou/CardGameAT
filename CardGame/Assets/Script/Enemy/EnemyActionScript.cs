using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyActionScript : MonoBehaviour
{
    [SerializeField,Header("�G�l�~�[�̍s���f�[�^")]
    private EnemyActionDataList enemyActionDataList;

    [SerializeField, Header("�s���e�L�X�g")]
    private Text text;

    private Turn turnManager;
    private GameObject player;

    //���݂̍s�����X�g�̃C���f�b�N�X
    private int currentActionIndex;

    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.FindObjectOfType<Turn>();
        player = GameObject.Find("Player");

        currentActionIndex = 0;

        text.text = enemyActionDataList.type[currentActionIndex].actionName;
        text.text += enemyActionDataList.type[currentActionIndex].actionValue;
    }

    // Update is called once per frame
    void Update()
    {
        if(!turnManager.isPlayerTurn)
        {
            EnemyAction(); 
        }
    }

    private void EnemyAction()
    {
        EnemyAction data = enemyActionDataList.type[currentActionIndex];

        //�܂��͍s���̎�ނ��m�F����
        switch (data.actionType)
        {
            case ENEMYACTIONTYPE.ATTACK:

                player.GetComponent<CharStatus>().Damage(data.actionValue);
                break;
            case ENEMYACTIONTYPE.DEF:
                break;
            case ENEMYACTIONTYPE.BUFF:
                break;
        }


        //�s���I���㎟�̍s���ɍs���悤�ɃC���f�b�N�X��ύX����
        if (enemyActionDataList.type.Length -1 <= currentActionIndex)
        {
            currentActionIndex = 0;
        }
        else
        {
            currentActionIndex++;
        }
        

        //�e�L�X�g�ύX
        text.text = enemyActionDataList.type[currentActionIndex].actionName;
        text.text += enemyActionDataList.type[currentActionIndex].actionValue;

        //�Ō�ɍs�����I������^�[����n��
        turnManager.GoTurnPlayer();
    }
}
