using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetObject : MonoBehaviour
{
    // ī�޶� ����
    public Camera getCamera;

    // �����ɽ�Ÿ�� �ǵ帰 ���� ����ؼ� �־�δ� ��
    private RaycastHit hit;

    void Update()
    {
        // ���콺 Ŭ���� �ϸ�
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 �������� ����ؼ� ����
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            // ���콺 �����ǿ��� ���̸� ������ �ɸ��� hit�� ����
            if (Physics.Raycast(ray, out hit))
            {
                // ������Ʈ���� ����ؼ� ������ ����
                string objectName = hit.collider.gameObject.name;
                //������Ʈ ���� �ֿܼ� ǥ��
                Debug.Log(objectName);
            }
        }
    }
}
