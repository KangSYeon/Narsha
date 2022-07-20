using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f; //½ºÇÇµå
    Vector2 _position;

    void Start()
    {
        _position = transform.position;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            _position += speed * Time.deltaTime * Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _position += speed * Time.deltaTime * Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _position += speed * Time.deltaTime * Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _position += speed * Time.deltaTime * Vector2.right;
        }

        transform.position = _position;

    }
}
