using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    public int walkCount;
    protected int currentWalkCount;

    protected Vector2 vector;

    public Queue<string> queue;


    public BoxColider2D boxColider;
    public LayerMask layerMask;
    public Animator animator;

    public BoxColider2D boxColider;
    public LayerMask layerMask;
    public Animator animator;

    public void Move(string _dir, int _frequency = 5)
    {
        quene.Enquene(_dir);
        StartCoroutline(MoveCoroutline(_dir, _frequency));
    }

    IEnumerator MoveCourtoutline(string _dir, int _frequency)
    {
        while (queue.Count != 0)
        {

        }
    }

}
