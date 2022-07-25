using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//====�����ؾ� �� ���׵�====
//����� �÷��̾� ������(HP, MT �ҷ�����)


//��¥ ǥ���ϴ� Text�� �ð迡�� �ߺ��̰� UI���� �����ϱ�
//�����̺�Ʈ �ð� , �ϴ� 5�ʷ� �س����ϴ� ���߿� 60f�� �����ؾ���
// + ���߿� Ȯ�ο����� ���� ������� hour, ��ư�� �����

public class StateManager : MonoBehaviour
{
    [SerializeField]
    public Image HPGauge; //ü�°����� �̹���
    public float maxHP = 100; //�ִ�ü��
    public static float HP; //���� ü��
    public Text HPtext;//���� ü���� ǥ���ϴ� text

    [SerializeField]
    public Image MTGauge; //���ŷ°����� �̹���
    public float maxMT = 100; //�ִ����ŷ�
    public static float MT; //���� ���ŷ�
    public Text MTtext;//���� ���ŷ��� ǥ���ϴ� text

    public float madTime = 5; //�����̺�Ʈ �ð� , �ϴ� 5�ʷ� �س����ϴ� ���߿� 60f�� �����ؾ���
    public float _speed = 255f;//�����̺�Ʈ�� �����̴� ����
    public Image MadnessImage; //�����̺�Ʈ�� ������ �̹���
    private Color color;
    private WaitForSeconds waitTime = new WaitForSeconds(0.05f);





    //DataManager dataManager;
    //[SerializeField] GameObject theData;

    // Start is called before the first frame update
    void Start()
    {
        //dataManager = theData.GetComponent<DataManager>();

        if (true/*DataManager.instance.nowSlot == -1*/) //����� �����Ͱ� ���ٸ�(���� ������ -1�̶��)
        {
            HP = maxHP;
            MT = maxMT;
        }
        //����� �����Ͱ� �ִٸ�(��� �ҷ������� �˾ƺ���)


        Set_HP(HP);
        Set_MT(MT);

    }

    // Update is called once per frame
    void Update()
    {
        if (MT == 0)
        {
            Madness();
        }
    }


    public void Change_HP(float _value) //ü�º�ȭ�Լ�
    {
        HP += _value;
        Set_HP(HP);
        print("HP : " + HP);
    }
    public void Set_HP(float _value)
    {
        HP = _value;

        if (HP <= 0)
        {
            HP = 0;
            HPtext.text = "Dead";//����
            Debug.Log("Dead");
        }
        else
        {
            if (HP >= maxHP) //�ִ�ü���� �ʰ��ҽ�
            {
                HP = maxHP; //���� ü���� �ִ�ü������ ����
            }
            HPtext.text = string.Format("{0}/{1}", HP, maxHP); // ����ü��/�ִ�ü�� ǥ��
        }

        HPGauge.fillAmount = HP / maxHP;//������ UI����
    }

    public void Change_MT(float _value) //���ŷº�ȭ�Լ�
    {
        MT += _value;
        Set_MT(MT);
        print("MT : " + MT);
    }
    public void Set_MT(float _value)
    {
        MT = _value;

        if (MT <= 0)
        {
            MT = 0;
            MTtext.text = "Madness"; //����
            Debug.Log("Madness");
        }
        else
        {
            if (MT >= maxMT) //�ִ����ŷ��� �ʰ��ҽ�
            {
                MT = maxMT; //���� ���ŷ��� �ִ����ŷ����� ����
            }
            MTtext.text = string.Format("{0}/{1}", MT, maxMT); // �������ŷ�/�ִ����ŷ� ǥ��
        }
        MTGauge.fillAmount = MT / maxMT;//������ UI����

    }

    public void Madness() //�����̺�Ʈ
    {
        //Debug.Log("MadTime : " + MadTime);

        if (madTime >= 0)
        {            
            StartCoroutine(MadnessEvent(_speed)); //�����̴� ȿ�� 
            madTime -= UnityEngine.Time.deltaTime;  //�����̺�Ʈ �����ð� ����
            //Debug.Log("MadTime : " + madTime);
        }
        if (madTime < 0) //�����̺�Ʈ�ð��� 0���ϰ� �ɶ�
        {
            HP = 0; //ü�� 0���� ����
            MT = -1;
            Set_HP(0); //ü�� 0���� ����
            StopAllCoroutines(); //������ �������̴� �ڷ�ƾ ���� 
            color.a = 0f;
            MadnessImage.color = color;
            
        }
    }
    IEnumerator MadnessEvent(float _speed) //�����̴� ȿ���� �ڷ�ƾ
    {
        while (color.a < 1f)
        {
            color.a += _speed;
            MadnessImage.color = color;
            
            yield return waitTime;
        }
        while (color.a > 0f)
        {
            color.a -= _speed;
            MadnessImage.color = color;
            
            yield return waitTime;
        }
    }

    public void SaveState()//���µ����� ���尪 ����
    {
        DataManager.instance.nowPlayer.HP = HP;
        DataManager.instance.nowPlayer.MT = MT;
    }

    public void LoadState()//���µ����� ���尪 �ҷ�����
    {
        HP = DataManager.instance.nowPlayer.HP;
        MT = DataManager.instance.nowPlayer.MT;

        Set_HP(HP);
        Set_MT(MT);
    }

}


       
