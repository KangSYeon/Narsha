using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 팝업창에 초를 보여주는 타이머 함수
public class PopTimer : MonoBehaviour
{
    public Text timerTxt;
    public float time = 9f;
    private float selectCountdown;

    // Count 0일때 동작할 함수 삽입을 위해 클래스 불러옴.
    public GameObject ButtonClose;

    void Start()
    {
        selectCountdown = time;
    }

    void Update()
    {
        if (Mathf.Floor(selectCountdown) <= 0)
        {
            // Count 0일때 동작할 함수 삽입 - CloseButton 함수 불러옴.
            ButtonClose.GetComponent<ButtonClose>().CloseButton();
        }
        else
        {
            selectCountdown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountdown).ToString();
        }
    }
}
