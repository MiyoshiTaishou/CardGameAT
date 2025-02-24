using UnityEngine;
using UnityEngine.UI;

public class CharStatus : MonoBehaviour
{
    [SerializeField]
    CharData myData;

    [SerializeField,Header("HPスライダー")]
    Slider mySlider;

    [SerializeField, Header("シールドテキスト")]
    Text shiledText;

    int CurrentHP;
    int CurrentMP;
    int DownPoint;
    int shiledPoint;

    KisuuPassive Kisuu;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = myData.MaxHP;
        CurrentMP = myData.MaxMP;
        DownPoint = myData.DownPoint;
        shiledText.text = shiledPoint.ToString();

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

        shiledText.text = shiledPoint.ToString();
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
            //シールドがあるならそちらから減らす
            if(0 < shiledPoint)
            {
                shiledPoint -= _damage;
            }
            else
            {
                CurrentHP-= _damage;
            }

            //減らした結果シールドが0以下になったならその分をダメージとして与える
            if (shiledPoint <= 0)
            {
                CurrentHP -= Mathf.Abs(shiledPoint);
            }           
        }
    }

    public void Shiled(int _shiled)
    {
        shiledPoint += _shiled;
    }
}
