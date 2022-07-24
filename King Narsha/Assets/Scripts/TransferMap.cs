using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���̵��� ����ȯ���� �ϴ� �����ص�
//���� ������ : ���� �ٲ�鼭 fadein�Լ� �α׸� ��µǰ� ȿ���� �ȳ�Ÿ�� 
//���̵��� ��ǥ�̵����� �ٲ� �ذ�


public class TransferMap: MonoBehaviour
{
    public string transferMapName; //�̵��� ���� �̸�

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

        yield return new WaitForSeconds(1f); //fadeout���� ���


        //SceneManager.LoadScene(transferMapName); //���̵� ��ɾ�, ��ǥ�̵����� ������ ����

        theFade.FadeIn();//fadein
    }
}
