using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class KisuuPassive : MonoBehaviour
{
    Turn turn;
    int turnNum;

    public bool Kisuu = false;
    [SerializeField, Header("”{—¦")] public float conf;
    // Start is called before the first frame update
    void Start()
    {
        turn = GameObject.FindObjectOfType< Turn >().GetComponent<Turn>();
        turnNum = turn.currentTurnNum;
        KisuuCheck();
    }

    void KisuuCheck()
    {
        Kisuu=turnNum%2==0?false:true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
