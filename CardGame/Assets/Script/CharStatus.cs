using UnityEngine;
using UnityEngine.UI;

public class CharStatus : MonoBehaviour
{
    [SerializeField]
    CharData myData;

    [SerializeField,Header("HPスライダー")]
    Slider mySlider;

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
        if(CurrentHP <= 0)
        {
            Destroy(gameObject);
        }

        mySlider.value = (float)CurrentHP / myData.MaxHP;
    }

    public void Damage(int _damage)
    {
        if (0 < CurrentHP)
        {
            CurrentHP -= _damage;
        }
    }
}
