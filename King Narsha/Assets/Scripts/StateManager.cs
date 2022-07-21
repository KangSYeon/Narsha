using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private Image healthGauge; //체력게이지 이미지
    int maxHealth = 100; //최대체력
    public static int health; //현재 체력

    [SerializeField]
    private Image mentalityGauge; //정신력게이지 이미지
    int maxMentality = 100; //최대정신력
    public static int mentality; //현재 정신력

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

    public void MinusHealth(int number) //체력 마이너스
    {
        health -= number;
        print("health : "+health);
    }
    public void PlusHealth(int number) //체력 플러스
    {
        health += number;
        print("health : " + health);
    }
    public void MinusMentality(int number) //정신력 마이너스
    {
        mentality -= number;
        print("mentality : " + mentality);
    }
    
    public void PlusMentality(int number) //정신력 플러스
    {
        mentality += number;
        print("mentality : " + mentality);
    } 
}

       
