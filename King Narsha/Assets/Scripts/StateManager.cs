using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//====수정해야 할 사항들====
//저장된 플레이어 데이터(HP, MT 불러오기)


//날짜 표기하는 Text를 시계에서 잘보이게 UI에서 변경하기
//광기이벤트 시간 , 일단 5초로 해놨습니다 나중에 60f로 변경해야함
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

    public float madTime = 5; //광기이벤트 시간 , 일단 5초로 해놨습니다 나중에 60f로 변경해야함
    public float _speed = 255f;//광기이벤트때 깜빡이는 정도
    public Image MadnessImage; //광기이벤트때 깜빡일 이미지
    private Color color;
    private WaitForSeconds waitTime = new WaitForSeconds(0.05f);





    //DataManager dataManager;
    //[SerializeField] GameObject theData;

    // Start is called before the first frame update
    void Start()
    {
        //dataManager = theData.GetComponent<DataManager>();

        if (true/*DataManager.instance.nowSlot == -1*/) //저장된 데이터가 없다면(현재 슬롯이 -1이라면)
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


    public void Change_HP(float _value) //체력변화함수
    {
        HP += _value;
        Set_HP(HP);
        print("HP : " + HP);
    }
    public void Set_HP(float _value)
    {
        HP = _value;

        if (HP <= 0)
        {
            HP = 0;
            HPtext.text = "Dead";//죽음
            Debug.Log("Dead");
        }
        else
        {
            if (HP >= maxHP) //최대체력을 초과할시
            {
                HP = maxHP; //현재 체력을 최대체력으로 설정
            }
            HPtext.text = string.Format("{0}/{1}", HP, maxHP); // 현재체력/최대체력 표시
        }

        HPGauge.fillAmount = HP / maxHP;//게이지 UI변경
    }

    public void Change_MT(float _value) //정신력변화함수
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
            Debug.Log("Madness");
        }
        else
        {
            if (MT >= maxMT) //최대정신력을 초과할시
            {
                MT = maxMT; //현재 정신력을 최대정신력으로 설정
            }
            MTtext.text = string.Format("{0}/{1}", MT, maxMT); // 현재정신력/최대정신력 표시
        }
        MTGauge.fillAmount = MT / maxMT;//게이지 UI변경

    }

    public void Madness() //광기이벤트
    {
        //Debug.Log("MadTime : " + MadTime);

        if (madTime >= 0)
        {            
            StartCoroutine(MadnessEvent(_speed)); //깜빡이는 효과 
            madTime -= UnityEngine.Time.deltaTime;  //광기이벤트 남은시간 감소
            //Debug.Log("MadTime : " + madTime);
        }
        if (madTime < 0) //광기이벤트시간이 0이하가 될때
        {
            HP = 0; //체력 0으로 설정
            MT = -1;
            Set_HP(0); //체력 0으로 설정
            StopAllCoroutines(); //이전에 실행중이던 코루틴 무시 
            color.a = 0f;
            MadnessImage.color = color;
            
        }
    }
    IEnumerator MadnessEvent(float _speed) //깜빡이는 효과의 코루틴
    {
        while (color.a < 1f)
        {
            color.a += _speed;
            MadnessImage.color = color;
            
            yield return waitTime;
        }
        while (color.a > 0f)
        {
            color.a -= _speed;
            MadnessImage.color = color;
            
            yield return waitTime;
        }
    }

    public void SaveState()//상태데이터 저장값 변경
    {
        DataManager.instance.nowPlayer.HP = HP;
        DataManager.instance.nowPlayer.MT = MT;
    }

    public void LoadState()//상태데이터 저장값 불러오기
    {
        HP = DataManager.instance.nowPlayer.HP;
        MT = DataManager.instance.nowPlayer.MT;

        Set_HP(HP);
        Set_MT(MT);
    }

}


       
