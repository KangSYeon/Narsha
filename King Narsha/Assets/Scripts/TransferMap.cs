using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//StartPoint�� ��ġ�� �÷��̾� �̵�.


public class TransferMap : MonoBehaviour
{
    public string transferMapName; //�̵��� ���� �̸�

    public GameObject thePlayer;

    private FadeManager theFade;

    public GameObject target; //�̵�����ġ

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
            thePlayer.transform.position = target.transform.position; //�÷��̾ Ÿ���� ��ġ�� �̵�
            //theCamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
            Debug.Log("TransferMap");
            Debug.Log("thePlayerposition : " + thePlayer.transform.position.x + "," + thePlayer.transform.position.y);
        }
    }
    IEnumerator TransferCoroutine()
    {
        DataManager.instance.currentMapName = transferMapName;
        //theFade.FadeOut();//fadeout

        yield return new WaitForSeconds(1f); //fadeout���� ���

        thePlayer.transform.position = target.transform.position; //�÷��̾ Ÿ���� ��ġ�� �̵�

        Debug.Log("TransferMap");
        Debug.Log("thePlayerposition : " + thePlayer.transform.position.x + "," + thePlayer.transform.position.y);

        //theFade.FadeIn();//fadein
    }

    public void SaveMapName()
    {
        //DataManager.instance.PlayerMapName = nowMapName; //���� �÷��̾��� ���̸� ����
    }

}
