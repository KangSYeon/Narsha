using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

//게임 시작시 저장할 슬롯을 선택할 수 있게하는 기능

//세이브가 왜 save -1로 저장되는건지 알아보기


public class Select : MonoBehaviour
{
    public GameObject creat; // 빈슬롯 클릭시 뜨는 창
    public Text[] slotText; //슬롯칸에 들어갈 텍스트를 담을 배열
    public Text newPlayerName; //새로운 플레이어이름

    bool[] savefile = new bool[3]; //슬롯에 세이브파일이 존재하는지 여부

    private FadeManager theFade;

    // Start is called before the first frame update
    void Start()
    {
        //슬롯별로 저장된 데이터가 존재하는지 판단
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}")) //세이브파일이 존재한다면
            {
                savefile[i] = true; //세이브파일 존재여부를 true로 변경
                DataManager.instance.nowSlot = i; 
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.name; //슬롯이름을 플레이어이름으로 변경 + 만약 저장시간이나 진행상황 저장까지 슬롯에 표기하려면 따로 저장했다가 이부분에 추가
            }
            else 
            {
                slotText[i].text = "비어있음";
            }
        }
        DataManager.instance.DataClear();//불러온 데이터 클리어

        theFade = FindObjectOfType<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;
     
        if (savefile[number])// 저장된 데이터가 있을때
        {
            string data = File.ReadAllText(DataManager.instance.path + DataManager.instance.nowSlot.ToString()); //경로+파일이름+슬롯이름 
            DataManager.instance.nowPlayer = JsonUtility.FromJson<PlayerData>(data);

            //DataManager.instance.LoadData(); //데이터 불러오기
            GoGame(); // 게임씬으로 이동
        }
        else // 저장된 데이터가 없을때
        {
             Creat();
        }
    }

    public void Creat()
    {
        creat.gameObject.SetActive(true); //빈슬롯 클릭시 뜨는 창 생성
    }

    public void GoGame() //게임씬으로 이동
    {
        if (!savefile[DataManager.instance.nowSlot]) //저장된 데이터가 없을 때
        {
            DataManager.instance.nowPlayer.name = newPlayerName.text; //입력한 이름을 받아와서 nowPlayer이름에 적용          
        }

        StartCoroutine(TransferCoroutine());         
    }

    IEnumerator TransferCoroutine()
    {
        theFade.FadeOut();//fadeout

        yield return new WaitForSeconds(1f); //fadeout이후 대기

        SceneManager.LoadScene(1); // 게임씬 숫자입력, 게임씬으로 이동
       
        theFade.FadeIn();//fadein
    }
}
