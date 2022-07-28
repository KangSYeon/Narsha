using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System Serializable]
public class NPCmove
{
    [Tooltip("NPCMove�� üũ�ϸ� NPC�� ������")]
    public bool NPCmove;

    public string[] direction; //npc�� ������ ���� ����

    [Range(1,5)]
    public int frequency; //npc�� ������ �������� �󸶳� ������ ������ ���ΰ�
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
