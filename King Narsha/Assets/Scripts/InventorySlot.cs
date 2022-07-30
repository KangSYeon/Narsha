using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon; //아이템 아이콘 이미지
    public Text itemName_Text; //아이템 이름 text
    public Text itemCount_Text; //아이템 수량 text
    public GameObject selected_Item; //선택된 아이템 짙게보이게하는 Panel

    public void Additem(Item _item) //아이템 추가
    {
        itemName_Text.text = _item.itemName;
        icon.sprite = _item.itemIcon;

        /*if (Item.ItemType.Use == _item.itemType) //소모품이라면 "아이템 x n개"로 표시하는 부분. 오브젝트의 종류에 소모품(여러개겹쳐지는)이 있는지 모르겠어서 일단 주석처리해뒀습니다!
        {
            if (_item.itemCount > 0)
                itemCount_Text.text = "x " + _item.itemCount.ToString();
            else
                itemCount_Text.text = "";
        }*/ 
    }

    public void RemoveItem() //아이템 제거
    {
        itemCount_Text.text = "";
        itemName_Text.text = "";
        icon.sprite = null;
    }
}
