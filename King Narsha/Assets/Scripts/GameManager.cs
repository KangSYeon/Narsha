using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Game ��𼭵� grab it �ϱ� ���� instance ���� : static
    public static GameManager GetInstance() { Init(); return Instance; }
    public GameState State;

    void Awake()
    {
        Instance = this; //������ ������ �� ���� �Ŵ��� �ҷ�����
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        //switch -> tab -> ������ -> tab �� case �ڵ��ϼ�
        /*switch (newState)
        {
        }*/
    }

    static void Init()
    {
        if (Instance == null)
        {
            GameObject go = GameObject.Find("@GameManager");
            if (go == null)
            {
                go = new GameObject { name = "@GameManager" };
                go.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(go);
            Instance = go.GetComponent<GameManager>();
        }
    }



    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public Image portraitImg;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public TextAsset txt;
    string[,] Sentence;
    int lineSize, rowSize;

    public void Action(GameObject scanObj)
    {
        if (isAction)   // 실행 중이 아닐 때 대화창 없애기
        {
            isAction = false;
        }
        else    // 실행 중일 때 대화창 띄우기
        {
            isAction = true;
            scanObject = scanObj;

            // 스캔한 오브젝트의 id와 isNPC 정보를 가져와야 하기 때문에 objData script가 필요
            ObjData objData = scanObject.GetComponent<ObjData>();
            // objData의 id와 NPC인지 정보를 매개변수로 넘김
            Talk(objData.id, objData.isNPC);

        }
        talkPanel.SetActive(isAction);  // 대화창 활성화 상태에 따라 대화창 활성화 변경
    }

    // 실제 대사들을 UI에 출력하는 함수
    void Talk(int id, bool isNPC)
    {
        // talkManger에 생성한 대사를 반환하는 함수를 이용하여 대사 한 줄을 입력받음
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        // 입력받은 대사를 이용하여 출력
        if (isNPC)
        {
            talkText.text = talkData;

            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            // NPC가 아닐 경우 안 보이도록 색 조정
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    void Start()
    {
        // 엔터 단위와 탭으로 나눠서 배열의 크기 조절
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        print(currentText);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        Sentence = new string[lineSize, rowSize];

        // 한 줄에서 탭으로 나눔
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for(int j=0; j<rowSize; j++)
            {
                Sentence[i, j] = row[j];
            }
        }
    }

}

public enum GameState
{
    //������ ���¸� �����ϴ� ��� ��Ҹ� �����ϸ� �˴ϴ�. (enum)
    //Example, ���� ���ӿ��� ������ ���°� �ֽ��ϴ�. ������ �������� Madness�� �ϰڽ��ϴ�. �Ʒ��� Example�Դϴ�.
    //Madness,
    //NormalGame,
    //ErrorGame
}

