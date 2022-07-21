using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 마우스 클릭 시 오브젝트 이름을 콘솔창에 띄우기
public class GetObject : MonoBehaviour
{
    //카메라 지정
    public Camera getCamera;

    //레이케스타가 건드린 것을 취득해서 넣어두는 곳
    public RaycastHit hit;

    void Update()
    {
        // 마우스 클릭을 하면
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 포지션을 취득해서 대입
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            // 마우스 포지션에서 레이를 던져서 걸리면 hit에 넣음
            if (Physics.Raycast(ray, out hit))
            {
                // 오브젝트명을 취득해서 변수에 넣음
                string objectName = hit.collider.gameObject.name;
                //오브젝트 명을 콘솔에 표시
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
