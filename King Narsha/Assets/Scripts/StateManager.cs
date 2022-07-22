using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//====�����ؾ� �� ���׵�====
//����� �÷��̾� ������(HP, MT �ҷ�����)
//�� �̵��Ŀ��� �����ǵ��� �ؾ���
//��¥ ǥ���ϴ� Text�� �ð迡�� �ߺ��̰� UI���� �����ϱ�

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

    // Start is called before the first frame update
    void Start()
    {

        if (true) //����� �����Ͱ� ���ٸ�
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
        
    }


    public void Change_HP(float _value)
    {
        HP += _value;
        Set_HP(HP);
        print("HP : " + HP);
    }

    public void Set_HP(float _value)
    {
        HP = _value;

        if (HP <= 0 )
        {
            HP = 0; 
            HPtext.text = "Dead";//����
        }
        else
        {
            if(HP >= maxHP)
            {
                HP = maxHP;
            }
           HPtext.text = string.Format("{0}/{1}", HP, maxHP); // ����ü��/�ִ�ü�� ǥ��
        }

        HPGauge.fillAmount = HP / maxHP; 
    }

    public void Change_MT(float _value)
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
        }
        else
        {
            if (MT >= maxMT)
            {
                MT = maxMT;
            }
           MTtext.text = string.Format("{0}/{1}", MT, maxMT); // �������ŷ�/�ִ����ŷ� ǥ��
        }
        MTGauge.fillAmount = MT / maxMT;
    }
}


       
