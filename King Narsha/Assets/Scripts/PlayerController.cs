using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerController : MonoBehaviour
{
    public PlayerData playerData;

    [ContextMenu("To Json Data")]
    void SavePlayerDataToJson()
    {
        string jsonData = JsonUtility.ToJson(playerData, true);
        string path = Path.Combine(Application.dataPath, "playerData.json"); //������ ������ ���
        File.WriteAllText(path, jsonData);
        Debug.Log("ToJoson : " + jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadPlayerDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json"); //������ ������ ���
        string jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);       
    }
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public int time; //�ð�
    public int health; //ü��
    public int mentality; //���ŷ�
    public string[] items; //������ �����۵�
    public string currentSceneName; //��ġ�� ��

    public void printData() 
    {
        Debug.Log("name : " + name);
        Debug.Log("time : " + time);
        Debug.Log("health : " + health);
        Debug.Log("mentality : " + mentality);
        Debug.Log("items : " + items);
        Debug.Log("currentSceneName : " + currentSceneName);
    }
}
