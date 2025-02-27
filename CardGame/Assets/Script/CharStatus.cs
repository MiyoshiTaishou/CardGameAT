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
    int attackBuffPoint;
    int defBuffPoint;

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
            //アタックバフ分攻撃力足す
            float daada = _damage + attackBuffPoint;
            if (Kisuu.Kisuu) 
            {
                daada *= Kisuu.conf;
                _damage = (int)daada;
            }
        }
        if (0 < CurrentHP)
        {
            //アタックバフ分攻撃力足す
            _damage += attackBuffPoint;

            //シールドがあるならそちらから減らす
            if (0 < shiledPoint)
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

        Debug.Log("与えたダメージ" + _damage);
        Debug.Log("現在の攻撃力" + attackBuffPoint);
    }

    public void Shiled(int _shiled)
    {
        //バフ分防御値を上げる
        _shiled += defBuffPoint;
        shiledPoint += _shiled;
    }

    public void AddBuff(int _attackbuff)
    {
        Debug.Log("バフ" + _attackbuff);
        attackBuffPoint += _attackbuff;
    }
}
