using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text timeText;//��¥�� �ð��� ǥ���� �ؽ�Ʈ

    float timeElapsed = 0;
    float day = 0; //���ӽð��� ��¥
    float hour = 0; //���ӽð��� �ð�����
    int timeTohour = 60; // ���ǽð�(1��)�� ���ӽð�(1�ð�)�� ����

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
            timeElapsed += UnityEngine.Time.deltaTime; //�ʴ����� �ð��� ����. ��ŸŸ������ �����Ӹ��� �ð�����
            hour = timeElapsed / timeTohour; //���ӽð��� ������ ��ȯ
            day = hour / 24; //���ӻ��� ��¥;

            timeText.text = "DAY : " + day.ToString("0.00") + "\nHOUR : " + hour.ToString("0.00"); //���ڸ����� ǥ��  
        }
    }

    public void Pause() //������ �𸣰ڴµ� �ð��� ����������..
    {
        Debug.Log(timeActive);
        timeActive = !timeActive;
    }

}
