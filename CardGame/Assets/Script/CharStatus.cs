using UnityEngine;
using UnityEngine.UI;

public class CharStatus : MonoBehaviour
{
    [SerializeField]
    CharData myData;

    [SerializeField,Header("HP�X���C�_�[")]
    Slider mySlider;

    [SerializeField, Header("�V�[���h�e�L�X�g")]
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
            //�V�[���h������Ȃ炻���炩�猸�炷
            if(0 < shiledPoint)
            {
                shiledPoint -= _damage;
            }
            else
            {
                CurrentHP-= _damage;
            }

            //���炵�����ʃV�[���h��0�ȉ��ɂȂ����Ȃ炻�̕����_���[�W�Ƃ��ė^����
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
