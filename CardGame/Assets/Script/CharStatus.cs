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
            //�A�^�b�N�o�t���U���͑���
            float daada = _damage + attackBuffPoint;
            if (Kisuu.Kisuu) 
            {
                daada *= Kisuu.conf;
                _damage = (int)daada;
            }
        }
        if (0 < CurrentHP)
        {
            //�A�^�b�N�o�t���U���͑���
            _damage += attackBuffPoint;

            //�V�[���h������Ȃ炻���炩�猸�炷
            if (0 < shiledPoint)
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

        Debug.Log("�^�����_���[�W" + _damage);
        Debug.Log("���݂̍U����" + attackBuffPoint);
    }

    public void Shiled(int _shiled)
    {
        //�o�t���h��l���グ��
        _shiled += defBuffPoint;
        shiledPoint += _shiled;
    }

    public void AddBuff(int _attackbuff)
    {
        Debug.Log("�o�t" + _attackbuff);
        attackBuffPoint += _attackbuff;
    }
}
