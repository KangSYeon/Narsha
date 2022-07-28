using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public string characterName;

public class OrderManager : MonoBehaviour
{
    private PlayerManager thePlayer; //�̺�Ʈ ���߿� Ű�Է� ó�� ����
    private List<MovingObject> charcters;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    public void PreLoadCharacter()
    {
        characters = ToList():
    }

    public List<MovingObject> ToList()
    {
        List<MovingObject> templist = new List<MovingObject>();
        MovingObject[] temp = FindObjectsOfType<MovingObject>();
        for(int i = 0; i< temp.Length; i++)
        {
            templist.Add(temp[i]);
        }
        return tempList;
    }

    public void Move(string _name, string _dir)
    {
        for(int i = 0; i < characters.Count; i++)
        {
            if(_name == characters[i].characterName)
            {
                characters[i].Move(_dir);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
