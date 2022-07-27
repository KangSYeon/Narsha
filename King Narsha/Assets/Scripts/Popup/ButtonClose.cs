using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClose : MonoBehaviour
{
    public GameObject button;
    public GameObject popupPanel;

    public void CloseButton()
    {
            popupPanel.SetActive(false);
    }
    
}
