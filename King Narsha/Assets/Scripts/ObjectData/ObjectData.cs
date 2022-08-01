using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ν�����â���� ��������
[System.Serializable]
public class ObjectData
{
    [Tooltip("é��")]
    public string[] chapter;

    [Tooltip("������Ʈ��")]
    public string objectName;

    [Tooltip("�����۸�")]
    public string[] itemName;

    [Tooltip("����")]
    public string[] quantity;

    [Tooltip("���� ����")]
    public string[] own;

    [Tooltip("����")]
    public string[] explanation;

}

[System.Serializable]
public class ObjectEvent
{

    //�̺�Ʈ �̸�
    public string name;

    public Vector2 line;
    public ObjectData[] objects;

}