using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//인스펙터창에서 수정가능
[System.Serializable]
public class Dialogue
{
    [Tooltip("대사 번호")]
    public string[] dialogueNum;

    [Tooltip("발화자")]
    public string name;

    [Tooltip("대사")]
    public string[] contexts;

    [Tooltip("이벤트 번호")]
    public string[] eventNum;

    [Tooltip("초상화 번호")]
    public string[] portraitNum;

    [Tooltip("좌표")]
    public string[] position;

    [Tooltip("조건")]
    public string[] skipNum;

    [Tooltip("팝업창 번호")]
    public string[] popNum;

}

[System.Serializable]
public class DialogueEvent
{

    //이벤트 이름
    public string name;

    public Vector2 line;
    public Dialogue[] dialogues;

}