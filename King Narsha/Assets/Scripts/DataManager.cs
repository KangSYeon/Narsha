using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//HP, MT, DAY, HOUR�� �����ϰ� �ҷ����� �Ϸ�
//select������ �Ѿ�ö��� ���� �ذ��ؾ���


public class PlayerData 
{
    public string name;
    public float Day = 1; //��¥
    public float Hour = 0 ; //�ð�
    public float HP = 100; //ü��
    public float MT = 100; //���ŷ�
    public string[] items; //������ �����۵�
    public string currentSceneName; //��ġ�� ��
}


public class DataManager : MonoBehaviour
{
    //�̱���
    public static DataManager instance;
    public PlayerData nowPlayer = new PlayerData();
    public string path; //������ ���
    public int nowSlot;//���� ����

    //private StateManager stateManager;
    //private TimeManager timeManager;

    private void Awake()
    {
        #region �̱���
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
        //stateManager.GetComponent<StateManager>().SaveState(); //��������
        //timeManager.GetComponent<TimeManager>().SaveTime(); //�ð�����

        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path+ nowSlot.ToString(), data); //���+�����̸�+�����̸� 
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString()); //���+�����̸�+�����̸� 
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);

        //stateManager.GetComponent<StateManager>().LoadState(); //���ºҷ����� + UI����
        //timeManager.GetComponent<TimeManager>().SaveTime(); //�ð��ҷ����� +UI����
    }

    public void DataClear() //����� �����Ͱ��������
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
