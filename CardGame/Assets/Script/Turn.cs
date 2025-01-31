using UnityEngine;

public class Turn : SingletonMonoBehaviour<Turn>
{
    public bool isPlayerTurn = true;
    public int currentTurnNum = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoTurnPlayer()
    {
        isPlayerTurn= true;
        currentTurnNum++;
    }

    public void GoTurnEnemy()
    {
        isPlayerTurn = false;
    }
}
