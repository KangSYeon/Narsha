using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 대화창 팝업 관련 스크립트
public class PopupManager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {   // Exit Action
            isAction = false;
        }
        else
        {   // Enter Action
            isAction = true;
            scanObject = scanObj;
            talkText.text = "이것의 이름은 " + scanObject.name + "입니다";
        }
        talkPanel.SetActive(isAction);
    }

}
