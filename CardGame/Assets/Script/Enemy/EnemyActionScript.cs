using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyActionScript : MonoBehaviour
{
    [SerializeField,Header("エネミーの行動データ")]
    private EnemyActionDataList enemyActionDataList;

    [SerializeField, Header("行動テキスト")]
    private Text text;

    private Turn turnManager;
    private GameObject player;

    //現在の行動リストのインデックス
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

        //まずは行動の種類を確認する
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


        //行動終了後次の行動に行くようにインデックスを変更する
        if (enemyActionDataList.type.Length -1 <= currentActionIndex)
        {
            currentActionIndex = 0;
        }
        else
        {
            currentActionIndex++;
        }
        

        //テキスト変更
        text.text = enemyActionDataList.type[currentActionIndex].actionName;
        text.text += enemyActionDataList.type[currentActionIndex].actionValue;

        //最後に行動を終えたらターンを渡す
        turnManager.GoTurnPlayer();
    }
}
