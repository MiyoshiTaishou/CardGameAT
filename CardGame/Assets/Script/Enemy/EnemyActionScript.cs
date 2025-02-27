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
        TextColorChangeTypeAction();
    }

    // Update is called once per frame
    void Update()
    {
        if(!turnManager.isPlayerTurn)
        {
            Debug.Log("�G�l�~�[�̃^�[���ł�" + turnManager.isPlayerTurn);
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

                //�_���[�W�^����
                player.GetComponent<CharStatus>().Damage(data.actionValue);

                break;
            case ENEMYACTIONTYPE.DEF:

                //�h��l�𑝂₷
                GetComponent<CharStatus>().Shiled(data.actionValue);

                break;
            case ENEMYACTIONTYPE.BUFF:

                //��炤�_���[�W���グ��
                player.GetComponent<CharStatus>().AddBuff(data.actionValue);

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
        TextColorChangeTypeAction();

        //�Ō�ɍs�����I������^�[����n��
        Debug.Log("�G�l�~�[�̍s���I��");
        turnManager.GoTurnPlayer();
    }

    void TextColorChangeTypeAction()
    {
        //�G�l�~�[�̍s���ɂ���ĕ����̐F��ς��鏈��
        switch (enemyActionDataList.type[currentActionIndex].actionType) 
        {
            case ENEMYACTIONTYPE.ATTACK:

                text.color = Color.red;

                break;

            case ENEMYACTIONTYPE.DEF:

                text.color = Color.blue;

                break;

            case ENEMYACTIONTYPE.BUFF:

                text.color = Color.green;

                break;
        }
    }
}
