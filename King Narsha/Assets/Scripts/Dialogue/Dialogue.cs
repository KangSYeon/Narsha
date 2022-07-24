using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ν�����â���� ��������
[System.Serializable]
public class Dialogue
{
    [Tooltip("��� ��ȣ")]
    public string[] dialoguenum;

    [Tooltip("��ȭ��")]
    public string name;

    [Tooltip("���")]
    public string[] contexts;

    [Tooltip("�̺�Ʈ ��ȣ")]
    public string[] number;

    [Tooltip("�ʻ�ȭ ��ȣ")]
    public string[] portraitnum;

    [Tooltip("����")]
    public string[] skipnum;

    [Tooltip("�˾�â ��ȣ")]
    public string[] popnum;

}

[System.Serializable]
public class DialgoueEvent
{

    //�̺�Ʈ �̸�
    public string name;

    public Vector2 line;
    public Dialogue[] dialogues;

}