using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonPop : MonoBehaviour
{
    public GameObject button;
    public GameObject popupPanel;

    public void Popup()
    {
        popupPanel.SetActive(true);    }

}
