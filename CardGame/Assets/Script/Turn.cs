using UnityEngine;

public class Turn : SingletonMonoBehaviour<Turn>
{
    public bool isPlayerTurn = true;
    public int currentTurnNum = 1;

    [SerializeField,Header("カードマネージャ")]
    CardManager cardManager;

    // Start is called before the first frame update
    void Start()
    {
        //カードを5毎引く
        cardManager.GenerateCards(5);
        cardManager.GetHandCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoTurnPlayer()
    {
        //カードを5毎引く
        cardManager.GenerateCards(5);
        cardManager.GetHandCards();
        isPlayerTurn = true;
        currentTurnNum++;
    }

    public void GoTurnEnemy()
    {
        //手札をすべて捨てる
        cardManager.DiscardAllCards();

        isPlayerTurn = false;
    }
}
