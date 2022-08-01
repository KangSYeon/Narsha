using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//인스펙터창에서 수정가능
[System.Serializable]
public class ObjectData
{
    [Tooltip("챕터")]
    public string[] chapter;

    [Tooltip("오브젝트명")]
    public string objectName;

    [Tooltip("아이템명")]
    public string[] itemName;

    [Tooltip("수량")]
    public string[] quantity;

    [Tooltip("보유 여부")]
    public string[] own;

    [Tooltip("설명")]
    public string[] explanation;

}

[System.Serializable]
public class ObjectEvent
{

    //이벤트 이름
    public string name;

    public Vector2 line;
    public ObjectData[] objects;

}