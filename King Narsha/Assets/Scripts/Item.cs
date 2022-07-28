using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item 
{
    public int itemID; //�������� ���� ID��. �ߺ� �Ұ���
    public string itemName; //�������� �̸�. �ߺ�����
    public string itemDescription; //������ ����
    public int itemCount;//������ ������ ����
    public Sprite itemIcon; //�������� ������

    public Item(int _itemID, string _itemName, string _itemDes, int _itemCount = 1)//������
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemCount = _itemCount;
        itemIcon = Resources.Load("ItemIcon/" + _itemID.ToString(), typeof(Sprite)) as Sprite;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
