using UnityEngine;
using System.Collections;
public class Control : MonoBehaviour
{
    // Update is called once per frame
    int speed = 10; //���ǵ� 
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x������ �̵��� ��
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y������ �̵��Ҿ�
        this.transform.Translate(new Vector3(xMove, yMove, 0));  //�̵�

    }
}