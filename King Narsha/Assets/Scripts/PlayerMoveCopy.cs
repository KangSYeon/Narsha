using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMoveCopy : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f; //½ºÇÇµå
    Vector2 _position;

    void Start()
    {
        _position = transform.position;
    }

    Rigidbody2D rigid;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;

    public GameManager manager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if (manager.isAction == true)
        //{
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


        //}

        //Direction
        if (Input.GetKey(KeyCode.W))
            dirVec = Vector3.up;
        else if (Input.GetKey(KeyCode.S))
            dirVec = Vector3.down;
        else if (Input.GetKey(KeyCode.A))
            dirVec = Vector3.left;
        else if (Input.GetKey(KeyCode.D))
            dirVec = Vector3.right;

        //Scan Object
        if(Input.GetKey(KeyCode.Space)&& scanObject != null)
        {
            //Debug.Log("This is "+ scanObject.name);
            manager.Action(scanObject);
        }


    }

    private void FixedUpdate()
    {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity =moveVec * speed;

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, dirVec, 0.5f, LayerMask.GetMask("Object"));

        if(rayhit.collider != null){
            scanObject = rayhit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }

    

    //if (Input.GetKey(KeyCode.Space))
    //{
    //    int k = 0;
    //    talktext.GetComponent<Text>().text = dia.contexts[k];
    //    //Debug.Log(dia.contexts[k]);
    //    k++;
    //}



   

}
