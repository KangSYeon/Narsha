using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ν�����â���� ��������
[System.Serializable]
public class Dialogue
{
    [Tooltip("��� ��ȣ")]
    public string[] dialogueNum;

    [Tooltip("��ȭ��")]
    public string name;

    [Tooltip("���")]
    public string[] contexts;

    [Tooltip("�̺�Ʈ ��ȣ")]
    public string[] eventNum;

    [Tooltip("�ʻ�ȭ ��ȣ")]
    public string[] portraitNum;

    [Tooltip("��ǥ")]
    public string[] position;

    [Tooltip("����")]
    public string[] skipNum;

    [Tooltip("�˾�â ��ȣ")]
    public string[] popNum;

}

[System.Serializable]
public class DialogueEvent
{

    //�̺�Ʈ �̸�
    public string name;

    public Vector2 line;
    public Dialogue[] dialogues;

}