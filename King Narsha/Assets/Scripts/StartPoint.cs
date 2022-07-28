using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//좌표이동으로변경
//변경할 맵위치(TransferPoint == StartPoint)일때
//현재플레이어위치 = 이동할 맵의 StartPoint위치

public class StartPoint : MonoBehaviour
{
    public string startPoint; //맵 이동시. 플레이어가 시작될 위치
    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
       /* if (startPoint == DataManager.instance.currentMapName)
        {
            thePlayer.transform.position = this.transform.position;
        }*/

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
