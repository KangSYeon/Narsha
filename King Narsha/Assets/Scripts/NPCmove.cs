using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System Serializable]
public class NPCmove
{
    [Tooltip("NPCMove를 체크하면 NPC가 움직임")]
    public bool NPCmove;

    public string[] direction; //npc가 움직일 방향 설정

    [Range(1,5)]
    public int frequency; //npc가 움직일 방향으로 얼마나 빠르게 움직일 것인가
}

public class NPCmove : MonoBehaviour
{
    [SerializeField]
    public NPCmove npc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
