using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text timeText;//날짜와 시간을 표현할 텍스트

    float timeElapsed = 0;
    float day = 1; //게임시간의 날짜 ,1일부터 시작
    float hour = 0; //게임시간의 시간단위

    //DataManager dataManager;
    //[SerializeField] GameObject theData;


    int timeTohour = 30; // 현실시간(30초)과 게임시간(1시간)의 배율

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
            timeElapsed += UnityEngine.Time.deltaTime; //초단위의 시간을 저장. 델타타임으로 프레임마다 시간증가
            hour = timeElapsed / timeTohour; //게임시간의 단위로 변환            
            day = 1 + hour / 24; //게임상의 날짜

            float textDay = Mathf.Floor(day); //소수점아래 버림
            float texthour = Mathf.Floor(hour); //소수점아래 버림

            ClockMove();

            timeText.text = "DAY : " + textDay.ToString("0") + "\nHOUR : " + texthour.ToString("0"); //한자리수만 표시  
            //Debug.Log(hour);
        }
    }

    public void Pause() 
    {
        Debug.Log(timeActive);
        timeActive = !timeActive;
    }

    void ClockMove() //시계 시침(ShortClock), 분침(LongClock) 이동
    {
        ShortClock.transform.Rotate(0, 0, -UnityEngine.Time.deltaTime); //델타타임 * 30 / timeTohour
        LongClock.transform.Rotate(0, 0, -UnityEngine.Time.deltaTime * 12f); //델타타임 * 360 / timeTohour
    }

    public void SaveTime() //시간 저장데이터값 변경
    {
        DataManager.instance.nowPlayer.Day = day;
        DataManager.instance.nowPlayer.Hour = hour;
    }

    public void LoadTime() //시간 데이터저장값 가져오기
    {
        day = DataManager.instance.nowPlayer.Day;
        hour = DataManager.instance.nowPlayer.Hour;
    }
}
