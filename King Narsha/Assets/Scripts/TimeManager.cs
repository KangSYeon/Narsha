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

    //DataManager dataManager;
    //[SerializeField] GameObject theData;


    int timeTohour = 30; // ���ǽð�(30��)�� ���ӽð�(1�ð�)�� ����

    bool timeActive = true;

    public GameObject ShortClock;
    public GameObject LongClock;

    // Start is called before the first frame update
    void Start()
    {
        //dataManager = theData.GetComponent<DataManager>();
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
            day = 1 + hour / 24; //���ӻ��� ��¥

            float textDay = Mathf.Floor(day); //�Ҽ����Ʒ� ����
            float texthour = Mathf.Floor(hour); //�Ҽ����Ʒ� ����

            ClockMove();

            timeText.text = "DAY : " + textDay.ToString("0") + "\nHOUR : " + texthour.ToString("0"); //���ڸ����� ǥ��  
            //Debug.Log(hour);
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

    public void SaveTime() //�ð� ���嵥���Ͱ� ����
    {
        DataManager.instance.nowPlayer.Day = day;
        DataManager.instance.nowPlayer.Hour = hour;
    }

    public void LoadTime() //�ð� ���������尪 ��������
    {
        day = DataManager.instance.nowPlayer.Day;
        hour = DataManager.instance.nowPlayer.Hour;
    }
}
