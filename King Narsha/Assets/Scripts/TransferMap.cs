using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap: MonoBehaviour
{
    public string transferMapName; //�̵��� ���� �̸�

    //private MovingObject thePlayer; 

    private FadeManager theFade;


    // Start is called before the first frame update
    void Start()
    {
        //thePlayer = FindObjectType<MovingObject>();

        theFade = FindObjectOfType<FadeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //box�� ������ ����
    {
        if (collision.gameObject.name == "Player")  //box�� ���� ��ü�� �÷��̾���
        {
            //thePlayer.currentMapName = transferMapName; //�÷��̾��� ���̸� 
            StartCoroutine(TransferCoroutine());
        }
    }

    IEnumerator TransferCoroutine() 
    {
        theFade.FadeOut();//fadeout

        yield return new WaitForSeconds(1f); //fadeout���� ���

        SceneManager.LoadScene(transferMapName); //���̵� ��ɾ�

        theFade.FadeIn();//fadein

    }
}
