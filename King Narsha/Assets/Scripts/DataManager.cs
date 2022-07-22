using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData //초기값 미설정
{
    public string name;
    public int Day; //날짜
    public int Hour; //시간
    public int HP; //체력
    public int MT; //정신력
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
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path+ nowSlot.ToString(), data); //경로+파일이름+슬롯이름 
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString()); //경로+파일이름+슬롯이름 
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear() 
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }

}
