using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualDelete : MonoBehaviour
{
    static bool[] ManualResult = new bool[12]; //매뉴얼 true or false 배열

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<12; i++)
        {
            if (ManualResult[i] == true)
            {
                GameObject.Find("manualBg(1)").transform.GetChild(0).gameObject.SetActive(true);
            }

            else
            {
                GameObject.Find("manualBg(1)").transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
