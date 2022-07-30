using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon; //������ ������ �̹���
    public Text itemName_Text; //������ �̸� text
    public Text itemCount_Text; //������ ���� text
    public GameObject selected_Item; //���õ� ������ £�Ժ��̰��ϴ� Panel

    public void Additem(Item _item) //������ �߰�
    {
        itemName_Text.text = _item.itemName;
        icon.sprite = _item.itemIcon;

        /*if (Item.ItemType.Use == _item.itemType) //�Ҹ�ǰ�̶�� "������ x n��"�� ǥ���ϴ� �κ�. ������Ʈ�� ������ �Ҹ�ǰ(��������������)�� �ִ��� �𸣰ھ �ϴ� �ּ�ó���ص׽��ϴ�!
        {
            if (_item.itemCount > 0)
                itemCount_Text.text = "x " + _item.itemCount.ToString();
            else
                itemCount_Text.text = "";
        }*/ 
    }

    public void RemoveItem() //������ ����
    {
        itemCount_Text.text = "";
        itemName_Text.text = "";
        icon.sprite = null;
    }
}
