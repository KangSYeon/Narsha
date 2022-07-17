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
        string path = Path.Combine(Application.dataPath, "playerData.json"); //파일을 저장할 경로
        File.WriteAllText(path, jsonData);
        Debug.Log("ToJoson : " + jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadPlayerDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "playerData.json"); //파일을 가져올 경로
        string jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);       
    }
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public int time; //시간
    public int health; //체력
    public int mentality; //정신력
    public string[] items; //소지한 아이템들
    public string currentSceneName; //위치한 씬

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
