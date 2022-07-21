using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; //맵 이동시. 플레이어가 시작될 위치
    //private MovingObject thePlayer; 
    
    // Start is called before the first frame update
    void Start()
    {
        //thePlayer = FindObjectOfType<MovingObject>();

        /*if(startPoint == thePlayer.currentMapName)
        {
            //thePlayer.tranform.position = this.transform.position;
        } */    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
