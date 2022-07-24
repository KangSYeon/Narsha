using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//인스펙터창에서 수정가능
[System.Serializable]
public class Dialogue
{
    [Tooltip("대사 번호")]
    public string[] dialoguenum;

    [Tooltip("발화자")]
    public string name;

    [Tooltip("대사")]
    public string[] contexts;

    [Tooltip("이벤트 번호")]
    public string[] number;

    [Tooltip("초상화 번호")]
    public string[] portraitnum;

    [Tooltip("조건")]
    public string[] skipnum;

    [Tooltip("팝업창 번호")]
    public string[] popnum;

}

[System.Serializable]
public class DialgoueEvent
{

    //이벤트 이름
    public string name;

    public Vector2 line;
    public Dialogue[] dialogues;

}