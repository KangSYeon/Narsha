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
