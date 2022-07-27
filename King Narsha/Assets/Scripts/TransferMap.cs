using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//StartPoint�� ��ġ�� �÷��̾� �̵�.


public class TransferMap: MonoBehaviour
{
    public string transferMapName; //�̵��� ���� �̸�

    public GameObject thePlayer;

    private FadeManager theFade;

    public GameObject target;

    //private CameraManager theCamera;

    // Start is called before the first frame update
    void Start()
    {
        
        theFade = FindObjectOfType<FadeManager>();

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DataManager.instance.currentMapName = transferMapName;
            
            StartCoroutine(TransferCoroutine());
            //Debug.Log("TransferMap");
            Debug.Log(target.transform.position.x);
            Debug.Log(target.transform.position.y);
            Debug.Log(target.transform.position.z);
        }        
    }

    


    IEnumerator TransferCoroutine() 
    {
        theFade.FadeOut();//fadeout

        yield return new WaitForSeconds(1f); //fadeout���� ���

        thePlayer.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        Debug.Log("TransferMap");
        Debug.Log("thePlayerposition : "+ thePlayer.transform.position.x +","+ thePlayer.transform.position.y);


        theFade.FadeIn();//fadein
    }

    public void SaveMapName()
    {
        //DataManager.instance.PlayerMapName = nowMapName; //���� �÷��̾��� ���̸� ����
    }
}
