using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���콺 Ŭ�� �� ������Ʈ �̸��� �ܼ�â�� ����
public class GetObject : MonoBehaviour
{
    //ī�޶� ����
    public Camera getCamera;

    //�����ɽ�Ÿ�� �ǵ帰 ���� ����ؼ� �־�δ� ��
    public RaycastHit hit;

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

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

    //        if (hit.collider != null)
    //        {
    //            GameObject click_obj = hit.transform.gameObject;
    //            Debug.Log(click_obj.name);
    //        }
    //    }
    //}
}
