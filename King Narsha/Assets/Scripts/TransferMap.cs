using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap: MonoBehaviour
{
    public string transferMapName; //이동할 맵의 이름

    //private MovingObject thePlayer; 

    private FadeManager theFade;


    // Start is called before the first frame update
    void Start()
    {
        //thePlayer = FindObjectType<MovingObject>();

        theFade = FindObjectOfType<FadeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //box에 닿으면 실행
    {
        if (collision.gameObject.name == "Player")  //box에 닿은 객체가 플레이어라면
        {
            //thePlayer.currentMapName = transferMapName; //플레이어의 맵이름 
            StartCoroutine(TransferCoroutine());
        }
    }

    IEnumerator TransferCoroutine() 
    {
        theFade.FadeOut();//fadeout

        yield return new WaitForSeconds(1f); //fadeout이후 대기

        SceneManager.LoadScene(transferMapName); //맵이동 명령어

        theFade.FadeIn();//fadein

    }
}
