using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDataManager : MonoBehaviour
{
    public static ObjectDataManager instance;

    [SerializeField] string csv_FileName;

    Dictionary<int, ObjectData> objectDic = new Dictionary<int, ObjectData>();

    public static bool isFinish = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            ObjectDataParser theParser = GetComponent<ObjectDataParser>();
            ObjectData[] objects = theParser.Parse(csv_FileName);
            for (int i = 0; i < objects.Length; i++)
            {
                objectDic.Add(i + 1, objects[i]);
            }
            isFinish = true;
        }
    }

    public ObjectData[] GetDialogue(int _StartNum, int _EndNum)
    {
        List<ObjectData> objectList = new List<ObjectData>();

        for (int i = 0; i <= _EndNum - _StartNum; i++)
        {
            objectList.Add(objectDic[_StartNum + i]);
        }
        return objectList.ToArray();
    }
}
