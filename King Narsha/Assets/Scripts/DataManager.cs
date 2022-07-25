using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//HP, MT, DAY, HOUR값 저장하고 불러오기 완료
//select씬에서 넘어올때의 오류 해결해야함


public class PlayerData 
{
    public string name;
    public float Day = 1; //날짜
    public float Hour = 0 ; //시간
    public float HP = 100; //체력
    public float MT = 100; //정신력
    public string[] items; //소지한 아이템들
    public string currentSceneName; //위치한 씬
}


public class DataManager : MonoBehaviour
{
    //싱글톤
    public static DataManager instance;
    public PlayerData nowPlayer = new PlayerData();
    public string path; //저장할 경로
    public int nowSlot;//현재 슬롯

    //private StateManager stateManager;
    //private TimeManager timeManager;

    private void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Application.persistentDataPath + "/save";

        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveData()
    {
        //stateManager.GetComponent<StateManager>().SaveState(); //상태저장
        //timeManager.GetComponent<TimeManager>().SaveTime(); //시간저장

        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path+ nowSlot.ToString(), data); //경로+파일이름+슬롯이름 
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString()); //경로+파일이름+슬롯이름 
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);

        //stateManager.GetComponent<StateManager>().LoadState(); //상태불러오기 + UI변경
        //timeManager.GetComponent<TimeManager>().SaveTime(); //시간불러오기 +UI변경
    }

    public void DataClear() //저장된 데이터가없을경우
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }

    public void nowData()
    {
        Debug.Log(path);
        Debug.Log("Day :" + nowPlayer.Day);
        Debug.Log("Hour :"+ nowPlayer.Hour);
        Debug.Log("HP :" + nowPlayer.HP);
        Debug.Log("MT :" + nowPlayer.MT);
        //Debug.Log("items :" + nowPlayer.items);
        Debug.Log("currentSceneName :" + nowPlayer.currentSceneName);
    }

    
}
