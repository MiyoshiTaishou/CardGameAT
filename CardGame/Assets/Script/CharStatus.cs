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

    KisuuPassive Kisuu;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = myData.MaxHP;
        CurrentMP = myData.MaxMP;
        DownPoint = myData.DownPoint;
        Kisuu=GameObject.FindObjectOfType<KisuuPassive>().GetComponent<KisuuPassive>();
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
        if (Kisuu !=null) 
        {
            float daada = _damage;
            if (Kisuu.Kisuu) 
            {
                daada *= Kisuu.conf;
                _damage = (int)daada;
            }
        }
        if (0 < CurrentHP)
        {
            CurrentHP -= _damage;
        }
    }
}
