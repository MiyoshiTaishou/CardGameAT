using UnityEngine;

public class Turn : SingletonMonoBehaviour<Turn>
{
    public bool isPlayerTurn = true;
    public int currentTurnNum = 1;

    [SerializeField,Header("�J�[�h�}�l�[�W��")]
    CardManager cardManager;

    // Start is called before the first frame update
    void Start()
    {
        //�J�[�h��5������
        cardManager.GenerateCards(5);
        cardManager.GetHandCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoTurnPlayer()
    {
        //�J�[�h��5������
        cardManager.GenerateCards(5);
        cardManager.GetHandCards();
        isPlayerTurn = true;
        currentTurnNum++;
    }

    public void GoTurnEnemy()
    {
        //��D�����ׂĎ̂Ă�
        cardManager.DiscardAllCards();

        isPlayerTurn = false;
    }
}
