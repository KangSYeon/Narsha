using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text timeText;//��¥�� �ð��� ǥ���� �ؽ�Ʈ

    float timeElapsed = 0;
    float day = 1; //���ӽð��� ��¥ ,1�Ϻ��� ����
    float hour = 0; //���ӽð��� �ð�����
   
 

    int timeTohour = 30; // ���ǽð�(30��)�� ���ӽð�(1�ð�)�� ����

    bool timeActive = true;

    public GameObject ShortClock;
    public GameObject LongClock;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        StartTime();
        
    }
    
    void StartTime()
    {
      
        if (timeActive)
        {
            timeElapsed += UnityEngine.Time.deltaTime; //�ʴ����� �ð��� ����. ��ŸŸ������ �����Ӹ��� �ð�����
            hour = timeElapsed / timeTohour; //���ӽð��� ������ ��ȯ

            
            day = hour / 24; //���ӻ��� ��¥

            ClockMove();

            timeText.text = "DAY : " + day.ToString("0") + "\nHOUR : " + hour.ToString("0"); //���ڸ����� ǥ��  
        }
    }

    public void Pause() 
    {
        Debug.Log(timeActive);
        timeActive = !timeActive;
    }

    void ClockMove() //�ð� ��ħ(ShortClock), ��ħ(LongClock) �̵�
    {
        ShortClock.transform.Rotate(0, 0, -UnityEngine.Time.deltaTime); //��ŸŸ�� * 30 / timeTohour
        LongClock.transform.Rotate(0, 0, -UnityEngine.Time.deltaTime * 12f); //��ŸŸ�� * 360 / timeTohour
    }
}
