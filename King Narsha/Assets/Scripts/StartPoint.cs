using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǥ�̵����κ���
//������ ����ġ(TransferPoint == StartPoint)�϶�
//�����÷��̾���ġ = �̵��� ���� StartPoint��ġ

public class StartPoint : MonoBehaviour
{
    public string startPoint; //�� �̵���. �÷��̾ ���۵� ��ġ
    public GameObject thePlayer;
    //private DataManager PlayerData;

    // Start is called before the first frame update
    void Start()
    {
        
        //thePlayer = FindObjectOfType<MovingObject>(); //�÷��̾� ��ũ��Ʈ�� ���ξ�� public���� ������Ʈ ������
       

        /*if (startPoint == PlayerData.currentSceneName)
        {
            thePlayer.tranform.position = this.transform.position;
        }    */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
