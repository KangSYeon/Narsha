using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �˾�â�� �ʸ� �����ִ� Ÿ�̸� �Լ�
public class PopTimer : MonoBehaviour
{
    public Text timerTxt;
    public float time = 9f;
    private float selectCountdown;

    // Count 0�϶� ������ �Լ� ������ ���� Ŭ���� �ҷ���.
    public GameObject ButtonClose;

    void Start()
    {
        selectCountdown = time;
    }

    void Update()
    {
        if (Mathf.Floor(selectCountdown) <= 0)
        {
            // Count 0�϶� ������ �Լ� ���� - CloseButton �Լ� �ҷ���.
            ButtonClose.GetComponent<ButtonClose>().CloseButton();
        }
        else
        {
            selectCountdown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountdown).ToString();
        }
    }
}
