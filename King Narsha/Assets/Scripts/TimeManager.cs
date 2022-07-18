using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text timeText;//날짜와 시간을 표현할 텍스트

    float timeElapsed = 0;
    float day = 0; //게임시간의 날짜
    float hour = 0; //게임시간의 시간단위
    int timeTohour = 60; // 현실시간(1분)과 게임시간(1시간)의 배율

    bool timeActive = true;

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
            timeElapsed += UnityEngine.Time.deltaTime; //초단위의 시간을 저장. 델타타임으로 프레임마다 시간증가
            hour = timeElapsed / timeTohour; //게임시간의 단위로 변환
            day = hour / 24; //게임상의 날짜;

            timeText.text = "DAY : " + day.ToString("0.00") + "\nHOUR : " + hour.ToString("0.00"); //한자리수만 표시  
        }
    }

    public void Pause() //왜인지 모르겠는데 시간이 멈추지않음..
    {
        Debug.Log(timeActive);
        timeActive = !timeActive;
    }

}
