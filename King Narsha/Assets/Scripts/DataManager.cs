using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//�÷��̾� ��ġ���� �߰��ؾ���


public class PlayerData 
{
    public string name;

    public float Day = 1; //��¥
    public float Hour = 0 ; //�ð�

    public float HP = 100; //ü��
    public float MT = 100; //���ŷ�

    public string[] items; //������ �����۵�

    public string PlayerMapName; //��ġ�� ���̸�
    public int PlayerXPosition;
    public int PlayerYPosition;

}


public class DataManager : MonoBehaviour
{
    //�̱���
    public static DataManager instance;
    public PlayerData nowPlayer = new PlayerData();
    public string path; //������ ���
    public int nowSlot;//���� ����

    public string currentMapName; // transferMap ��ũ��Ʈ�� �ִ� transferMapName ������ ���� ����

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
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path+ nowSlot.ToString(), data); //���+�����̸�+�����̸� 
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString()); //���+�����̸�+�����̸� 
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
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
        Debug.Log("PlayerMapName :" + nowPlayer.PlayerMapName);
        Debug.Log("currentMapName :" + currentMapName);


    }
}
