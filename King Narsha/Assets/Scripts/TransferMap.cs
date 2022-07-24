using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//맵이동을 씬전환으로 일단 구현해둠
//현재 문제점 : 씬이 바뀌면서 fadein함수 로그만 출력되고 효과가 안나타남 
//맵이동을 좌표이동으로 바꿔 해결


public class TransferMap: MonoBehaviour
{
    public string transferMapName; //이동할 맵의 이름

    public GameObject thePlayer; 

    private FadeManager theFade;
    private DataManager PlayerData;


    // Start is called before the first frame update
    void Start()
    {
        //thePlayer = FindObjectType<MovingObject>();
        theFade = FindObjectOfType<FadeManager>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //PlayerData.currentSceneName = transferMapName;
            StartCoroutine(TransferCoroutine());
        }
        Debug.Log(PlayerData);
    }

    


    IEnumerator TransferCoroutine() 
    {
        theFade.FadeOut();//fadeout

        yield return new WaitForSeconds(1f); //fadeout이후 대기


        //SceneManager.LoadScene(transferMapName); //씬이동 명령어, 좌표이동으로 변경후 삭제

        theFade.FadeIn();//fadein
    }
}
