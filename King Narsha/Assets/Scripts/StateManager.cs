using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//====수정해야 할 사항들====
//저장된 플레이어 데이터(HP, MT 불러오기)
//씬 이동후에도 유지되도록 해야함
//날짜 표기하는 Text를 시계에서 잘보이게 UI에서 변경하기

// + 나중에 확인용으로 같이 출력중인 hour, 버튼들 지우기

public class StateManager : MonoBehaviour
{
    [SerializeField]
    public Image HPGauge; //체력게이지 이미지
    public float maxHP = 100; //최대체력
    public static float HP; //현재 체력
    public Text HPtext;//현재 체력을 표시하는 text

    [SerializeField]
    public Image MTGauge; //정신력게이지 이미지
    public float maxMT = 100; //최대정신력
    public static float MT; //현재 정신력
    public Text MTtext;//현재 정신력을 표시하는 text

    public float _speed = 255f;//광기이벤트때 깜빡이는 정도
    public Image MadnessImage; //광기이벤트때 깜빡일 이미지
    private Color color;
    private WaitForSeconds waitTime = new WaitForSeconds(0.05f);

    // Start is called before the first frame update
    void Start()
    {

        if (true) //저장된 데이터가 없다면
        {
            HP = maxHP; 
            MT = maxMT;  
        }
        //저장된 데이터가 있다면(어떻게 불러오는지 알아보기)


        Set_HP(HP);
        Set_MT(MT);

    }

    // Update is called once per frame
    void Update()
    {
        if (MT == 0)
        {
            Madness();
        }
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
            HPtext.text = "Dead";//죽음
        }
        else
        {
            if(HP >= maxHP)
            {
                HP = maxHP;
            }
           HPtext.text = string.Format("{0}/{1}", HP, maxHP); // 현재체력/최대체력 표시
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
            MTtext.text = "Madness"; //광기
        }
        else
        {
            if (MT >= maxMT)
            {
                MT = maxMT;
            }
           MTtext.text = string.Format("{0}/{1}", MT, maxMT); // 현재정신력/최대정신력 표시
        }
        MTGauge.fillAmount = MT / maxMT;
    }

    public void Madness()
    {
        float MadTime = 60f;

        if (MadTime > 0)
        {
            MadTime -= UnityEngine.Time.deltaTime;
            StartCoroutine(MadnessEvent(_speed));
        }
        if (MadTime <= 0)
        {
            HP = 0;
            Set_HP(0);
        }
    }
    IEnumerator MadnessEvent(float _speed)
    {
        while(color.a < 1f)
        {
            color.a += _speed;
            MadnessImage.color = color;
            yield return waitTime;
        }
        while(color.a >0f)
        {
            color.a -= _speed;
            MadnessImage.color = color;
            yield return waitTime;
        }
    }
}


       
