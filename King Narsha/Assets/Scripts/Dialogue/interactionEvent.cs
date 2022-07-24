using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionEvent : MonoBehaviour
{

    [SerializeField] DialgoueEvent dialogue;

    public Dialogue[] GetDialogue()
    {
        dialogue.dialogues = DatabaseManager.instance.GetDialogue((int)dialogue.line.x, (int)dialogue.line.y);
        return dialogue.dialogues;
    }

    //[SerializeField] SelectEvent select;

    //public SelectDialogue[] GetSelectes()
    //{
    //    select.Selecter = DatabaseManager.instance.GetSelects(1, s_lineY);
    //    return select.Selecter;
    //}

}