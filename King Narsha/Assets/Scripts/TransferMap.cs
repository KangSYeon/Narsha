using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//StartPoint의 위치로 플레이어 이동.


public class TransferMap : MonoBehaviour
{
    public string transferMapName; //이동할 맵의 이름

    public GameObject thePlayer;

    private FadeManager theFade;

    public GameObject target; //이동할위치

    //public CameraController theCamera;

    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //StartCoroutine(TransferCoroutine());
            thePlayer.transform.position = target.transform.position; //플레이어를 타켓의 위치로 이동
            //theCamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
            Debug.Log("TransferMap");
            Debug.Log("thePlayerposition : " + thePlayer.transform.position.x + "," + thePlayer.transform.position.y);
        }
    }
    IEnumerator TransferCoroutine()
    {
        DataManager.instance.currentMapName = transferMapName;
        //theFade.FadeOut();//fadeout

        yield return new WaitForSeconds(1f); //fadeout이후 대기

        thePlayer.transform.position = target.transform.position; //플레이어를 타켓의 위치로 이동

        Debug.Log("TransferMap");
        Debug.Log("thePlayerposition : " + thePlayer.transform.position.x + "," + thePlayer.transform.position.y);

        //theFade.FadeIn();//fadein
    }

    public void SaveMapName()
    {
        //DataManager.instance.PlayerMapName = nowMapName; //현재 플레이어의 맵이름 저장
    }

}
