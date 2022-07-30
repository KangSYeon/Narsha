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
    public CameraController theCamera;

    // Start is called before the first frame update
    void Start()
    {
       if (startPoint == DataManager.instance.currentMapName)
        {
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = this.transform.position;
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
