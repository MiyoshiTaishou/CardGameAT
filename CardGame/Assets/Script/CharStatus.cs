using UnityEngine;

public class CharStatus : MonoBehaviour
{
    [SerializeField]
    CharData myData;

    int CurrentHP;
    int CurrentMP;
    int DownPoint;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = myData.MaxHP;
        CurrentMP = myData.MaxMP;
        DownPoint = myData.DownPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
