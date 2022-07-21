using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private Image healthGauge; //ü�°����� �̹���
    int maxHealth = 100; //�ִ�ü��
    public static int health; //���� ü��

    [SerializeField]
    private Image mentalityGauge; //���ŷ°����� �̹���
    int maxMentality = 100; //�ִ����ŷ�
    public static int mentality; //���� ���ŷ�

    // Start is called before the first frame update
    void Start()
    {
        healthGauge = GetComponent<Image>();
        health = maxHealth;

        mentalityGauge = GetComponent<Image>();
        mentality = maxMentality;
    }

    // Update is called once per frame
    void Update()
    {
        //healthGauge.fillAmount = health / maxHealth;
        //mentalityGauge.fillAmount = mentality / maxMentality;
    }

    public void MinusHealth(int number) //ü�� ���̳ʽ�
    {
        health -= number;
        print("health : "+health);
    }
    public void PlusHealth(int number) //ü�� �÷���
    {
        health += number;
        print("health : " + health);
    }
    public void MinusMentality(int number) //���ŷ� ���̳ʽ�
    {
        mentality -= number;
        print("mentality : " + mentality);
    }
    
    public void PlusMentality(int number) //���ŷ� �÷���
    {
        mentality += number;
        print("mentality : " + mentality);
    } 
}

       
