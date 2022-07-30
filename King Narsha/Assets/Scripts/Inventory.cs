using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//������ �����ͺ��̽��� �����ؾ���
//�޴���� �����ϱ� ���� ��������
//ShowItem�� case�� ������ ����� �Լ� �ҷ�����
//���� �����ۼ���â���� Z�ѹ� �� ������ ����ϱ� or �׸��α� �� �������� ���� Ű�Է� ���߰� �ص׽��ϴ�


public class Inventory : MonoBehaviour
{
    /*
    private OrderManager theOrder; //Ű�Է�(����Ű �����̴°� ����)    
    */

    /* ���� �Ŵ��� �߰��� ����     
    private AudioManager theAudio;
    public string key_sound;
    public string enter_sound;
    public string cancel_sound;
    public string open_sound;
    public string beep_sound;
    */

    private InventorySlot[] slots; //�κ��丮 ���Ե�

    private List<Item> inventoryItemList; //�÷��̾ ������ ������ ����Ʈ.
    private List<Item> inventoryTabList; //�������ǿ� ���� �ٸ��� ������ ������ ����Ʈ�ε� �ϳ��� ������ �ҰŸ� �ʿ���ºκ�(1~n���� ���� �������)

    public Text Description_Text; //�ο�����
    public string[] tabDexcription; //�� �ο�����. 2

    public Transform tf; //slot�� �θ�ü. �̸� �̿��� slots�� ����

    public GameObject go;//�κ��丮 Ȱ��ȭ ��Ȱ��ȭ. 3
    public GameObject[] selectedTabImages; //���̹���. 4

    private int selectedItem;//���õ� ������
    private int selectedTab;//���õ� ��. 5

    private bool activated; //�κ��丮 Ȱ��ȭ�� true
    private bool tabActivated; //�� Ȱ��ȭ�� true. 6
    private bool itemActivated; //������ Ȱ��ȭ�� true
    private bool stopKeyInput; //Ű�Է� ����(����� �� ���ǰ� ���� �ٵ�, �� �� Ű�Է� ����)
    private bool preventExec; //�ߺ����� ����.

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);


    // Start is called before the first frame update
    void Start()
    {
        //theAudio = FindObjectType<AudioManager>();
        //theOrder = FindObjectType<OrderManager>(); 
        inventoryItemList = new List<Item>();
        inventoryTabList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();

        //�׽�Ʈ�� ������ ���� �κ�
        inventoryItemList.Add(new Item(10001, "�ɺ�", "����� �ɺ��̴�"));
        inventoryItemList.Add(new Item(10002, "ü�°�����", "ü�� �������̴�"));
        inventoryItemList.Add(new Item(10003, "�ð����", "�ð� �����̴�"));
        inventoryItemList.Add(new Item(10004, "���ŷ°�����", "���ŷ� �������̴�"));
        inventoryItemList.Add(new Item(10005, "������Ʈ", "������Ʈ�̴�"));
        inventoryItemList.Add(new Item(10006, "��ħ", "��ħ�̴�"));
        inventoryItemList.Add(new Item(10007, "��������", "���������̴�"));
        inventoryItemList.Add(new Item(10008, "��ħ", "��ħ�̴�"));
    }

    public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    }//�κ��丮 ���� �ʱ�ȭ

    public void ShowTab()
    {
        RemoveSlot();
        SelectedTab();
    }//�� Ȱ��ȭ
    public void SelectedTab() 
    {
        StopAllCoroutines();
        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
        color.a = 0f;
        for (int i = 0; i < selectedTabImages.Length; i++)
        {
            selectedTabImages[i].GetComponent<Image>().color = color;
        }
        Description_Text.text = tabDexcription[selectedTab];
        StartCoroutine(SelectedTabEffectCoroutine());
    }//���õ� ���� �����ϰ� �ٸ� ��� ���� �÷� ���İ� 0���� ����
    IEnumerator SelectedTabEffectCoroutine()
    {
        while (tabActivated)
        {
            Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
            while (color.a < 0.5f)
            {
                color.a += 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f); //��¦�̰� ��� ����
        }
    }//���õ� �� ��¦�� ȿ��

    public void ShowItem()
    {
        inventoryTabList.Clear(); //���� �ǿ� �ִ��� Ŭ����
        RemoveSlot();
        selectedItem = 0; //ó���� ù��° �������� �������� ǥ�õ�

        switch (selectedTab) 
        {
            case 0: //�κ��丮�Ǹ���Ʈ�� �߰�
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    //if (Item.ItemType.Use == inventoryItemList[i].itemType) 
                        inventoryTabList.Add(inventoryItemList[i]); //�����۸���Ʈ���� �������Ǹ���Ʈ�� ��
                }
                for (int i = 0; i < inventoryTabList.Count; i++) //�κ��丮 �� ����Ʈ�� �߰��ϱ�(case 0)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].Additem(inventoryTabList[i]);
                }//�κ��丮 �� ����Ʈ�� ������, �κ��丮 ���Կ� �߰�

                SelectedItem();
                break;
            case 1: //�Ŵ���
                Description_Text.text = "�Ŵ��� ��� �ֱ�";
                break;
            case 2: //save
                Description_Text.text = "SAVE ��� �ֱ�";
                break;
        }//�ǿ� ���� �з�.

        
    }//������ Ȱ��ȭ(inventoryTabList�� ���ǿ� �´� �����۵鸸 �־��ְ�, �κ��丮 ���Կ� ���)
    public void SelectedItem()
    {
        StopAllCoroutines();
        if (inventoryTabList.Count > 0) //�������ִ� �������� �ִٸ�
        {
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            color.a = 0f;

            for(int i = 0; i<inventoryTabList.Count; i++)
                slots[i].selected_Item.GetComponent<Image>().color = color; //�ٸ��κе� �� �������
            Description_Text.text = inventoryTabList[selectedItem].itemDescription;
            StartCoroutine(SelectedItemEffectCoroutine()); //���õ� ���� ��¦�Ÿ��� ȿ��
        }
        else
            Description_Text.text = "�ش� Ÿ���� �������� �����ϰ� ���� �ʽ��ϴ�.";
    }//���õ� �������� �����ϰ�, �ٸ� ��� ���� �÷� ���İ��� 0���� ����.
    IEnumerator SelectedItemEffectCoroutine()
    {
        while (itemActivated)
        {
            Color color = slots[selectedItem].GetComponent<Image>().color;
            while (color.a < 0.5f)
            {
                color.a += 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f); //��¦�̰� ��� ����
        }
    }//���õ� ������ ������ 


    // Update is called once per frame
    void Update()
    {
        if(!stopKeyInput)
        {
            if(Input.GetKeyDown(KeyCode.I))//iŰ ������ �κ��丮 ������
            {
                activated = !activated;

                if(activated) //�κ��丮 ������
                {
                    //theAudio.Play(open_sound);
                    //theOrder.NotMove();
                    go.SetActive(true);
                    selectedTab = 0;
                    tabActivated = true;
                    itemActivated = false;
                    ShowTab();
                }
                else //�κ��丮 ������
                {
                    //theAudio.Play(cancel_sound);
                    StopAllCoroutines();
                    go.SetActive(false);
                    tabActivated = false;
                    itemActivated = false;
                    //theOrder.Move();
                }
            }

            if(activated)
            {
                if(tabActivated) //���� Ȱ��ȭ������
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow)) //������Ű ���������
                    {
                        if (selectedTab < selectedTabImages.Length - 1) //���õ� �� �̹����� ��ĭ���������� �̵�
                            selectedTab++;
                        else //������ �ǿ��� �������� ������ 0��°�� ���ƿ�
                            selectedTab = 0;
                        //theAudio.Play(key_sound);
                        SelectedTab(); //���õ� �� ǥ��
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow)) //����Ű ���������
                    {
                        if (selectedTab > 0) //���õ� �� �̹����� ��ĭ�������� �̵�
                            selectedTab--;
                        else //ù��° �ǿ��� ������ ������ ����������
                            selectedTab = selectedTabImages.Length - 1;
                        //theAudio.Play(key_sound);
                        SelectedTab(); //���õ� �� ǥ��
                    }
                    else if (Input.GetKeyDown(KeyCode.Z)) //����Ű�� �������� (���Ƿ� Z�� ����������)
                    {
                        //theAudio.Play(enter_sound);
                        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
                        color.a = 0.25f;
                        selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                        itemActivated = true;
                        tabActivated = false;
                        preventExec = true; //�ǰ� �κ��丮�� ���̽������ �ʵ��� �ϴ� ����
                        ShowItem();
                    }
                } //�� Ȱ��ȭ�� Ű �Է� ó��

                else if(itemActivated)
                {
                    if (inventoryTabList.Count > 0)
                    {
                        if (Input.GetKeyDown(KeyCode.DownArrow)) //�Ʒ�Ű ������ +3(���ٿ� ���� ���Լ���ŭ +)
                        {
                            if (selectedItem < inventoryTabList.Count - 2)
                                selectedItem += 2;
                            else
                                selectedItem %= 2;
                            //theAudio.Play(key_sound);
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.UpArrow)) //��Ű ������
                        {
                            if (selectedItem > 1)
                                selectedItem -= 2;
                            else
                                selectedItem = inventoryTabList.Count - 1 - selectedItem;
                            //theAudio.Play(key_sound);
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            if (selectedItem < inventoryTabList.Count - 1)
                                selectedItem++;
                            else
                                selectedItem = 0;
                            //theAudio.Play(key_sound);
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                            if (selectedItem > 0)
                                selectedItem--;
                            else
                                selectedItem = inventoryTabList.Count - 1;
                            //theAudio.Play(key_sound);
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.Z) && !preventExec) //���� �������� �� �ȿ��� �� Z��������
                        {
                            if (selectedTab == 0) //ù��° ��
                            {
                                //theAudio.Play(enter_sound);
                                stopKeyInput = true; //�ٸ� Ű �Է� ����

                                //��¦�̴� ȿ�� ���߰� ���ѻ����� �����ؼ� ���� ���õȴ������� �����
                                //����Ͻðڽ��ϱ�? ���� ������ ȣ��                                   
                            }
                            else if (selectedTab == 1)
                            {
                                //�ι�° �ǿ��� Z��������. ���� �ƹ���ɾ���
                            }
                            else
                            {
                                //����° �ǿ��� Z��������. ���� �ƹ���ɾ���
                            }
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.X)) //�κ��丮���� ������ �ڷΰ���
                    {
                        //theAudio.Play(cancel_sound);
                        StopAllCoroutines();
                        itemActivated = false;
                        tabActivated = true;
                        ShowTab();
                    }
                } //�κ��丮 Ȱ��ȭ�� Ű �Է� ó��

                if (Input.GetKeyUp(KeyCode.Z)) //�ߺ����� ����
                    preventExec = false;                   
            }
        }
    }
}
