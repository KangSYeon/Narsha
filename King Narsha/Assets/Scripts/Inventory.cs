using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//아이템 데이터베이스와 연결해야함
//메뉴얼과 저장하기 탭의 문구변경
//ShowItem의 case에 각각의 기능의 함수 불러오기
//현재 아이템선택창에서 Z한번 더 누르면 사용하기 or 그만두기 등 선택지를 위해 키입력 멈추게 해뒀습니다


public class Inventory : MonoBehaviour
{
    /*
    private OrderManager theOrder; //키입력(방향키 움직이는거 관리)    
    */

    /* 사운드 매니저 추가후 적용     
    private AudioManager theAudio;
    public string key_sound;
    public string enter_sound;
    public string cancel_sound;
    public string open_sound;
    public string beep_sound;
    */

    private InventorySlot[] slots; //인벤토리 슬롯들

    private List<Item> inventoryItemList; //플레이어가 소지한 아이템 리스트.
    private List<Item> inventoryTabList; //선택한탭에 따라 다르게 보여질 아이템 리스트인데 하나의 탭으로 할거면 필요없는부분(1~n까지 숫자 적어놓음)

    public Text Description_Text; //부연설명
    public string[] tabDexcription; //탭 부연설명. 2

    public Transform tf; //slot의 부모객체. 이를 이용해 slots에 넣음

    public GameObject go;//인벤토리 활성화 비활성화. 3
    public GameObject[] selectedTabImages; //탭이미지. 4

    private int selectedItem;//선택된 아이템
    private int selectedTab;//선택된 탭. 5

    private bool activated; //인벤토리 활성화시 true
    private bool tabActivated; //탭 활성화시 true. 6
    private bool itemActivated; //아이템 활성화시 true
    private bool stopKeyInput; //키입력 제한(사용할 때 질의가 나올 텐데, 그 때 키입력 방지)
    private bool preventExec; //중복실행 제한.

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);


    // Start is called before the first frame update
    void Start()
    {
        //theAudio = FindObjectType<AudioManager>();
        //theOrder = FindObjectType<OrderManager>(); 
        inventoryItemList = new List<Item>();
        inventoryTabList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>();

        //테스트용 데이터 넣은 부분
        inventoryItemList.Add(new Item(10001, "꽃병", "평범한 꽃병이다"));
        inventoryItemList.Add(new Item(10002, "체력게이지", "체력 게이지이다"));
        inventoryItemList.Add(new Item(10003, "시계바탕", "시계 바탕이다"));
        inventoryItemList.Add(new Item(10004, "정신력게이지", "정신력 게이지이다"));
        inventoryItemList.Add(new Item(10005, "오브젝트", "오브젝트이다"));
        inventoryItemList.Add(new Item(10006, "분침", "분침이다"));
        inventoryItemList.Add(new Item(10007, "게이지통", "게이지통이다"));
        inventoryItemList.Add(new Item(10008, "시침", "시침이다"));
    }

    public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    }//인벤토리 슬롯 초기화

    public void ShowTab()
    {
        RemoveSlot();
        SelectedTab();
    }//탭 활성화
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
    }//선택된 탭을 제외하고 다른 모든 탭의 컬러 알파값 0으로 조정
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

            yield return new WaitForSeconds(0.3f); //반짝이고 잠시 지연
        }
    }//선택된 탭 반짝임 효과

    public void ShowItem()
    {
        inventoryTabList.Clear(); //기존 탭에 있던것 클리어
        RemoveSlot();
        selectedItem = 0; //처음엔 첫번째 아이템을 고른것으로 표시됨

        switch (selectedTab) 
        {
            case 0: //인벤토리탭리스트에 추가
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    //if (Item.ItemType.Use == inventoryItemList[i].itemType) 
                        inventoryTabList.Add(inventoryItemList[i]); //아이템리스트들이 아이템탭리스트에 들어감
                }
                for (int i = 0; i < inventoryTabList.Count; i++) //인벤토리 탭 리스트에 추가하기(case 0)
                {
                    slots[i].gameObject.SetActive(true);
                    slots[i].Additem(inventoryTabList[i]);
                }//인벤토리 탭 리스트의 내용을, 인벤토리 슬롯에 추가

                SelectedItem();
                break;
            case 1: //매뉴얼
                Description_Text.text = "매뉴얼 기능 넣기";
                break;
            case 2: //save
                Description_Text.text = "SAVE 기능 넣기";
                break;
        }//탭에 따른 분류.

        
    }//아이템 활성화(inventoryTabList에 조건에 맞는 아이템들만 넣어주고, 인벤토리 슬롯에 출력)
    public void SelectedItem()
    {
        StopAllCoroutines();
        if (inventoryTabList.Count > 0) //가지고있는 아이템이 있다면
        {
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            color.a = 0f;

            for(int i = 0; i<inventoryTabList.Count; i++)
                slots[i].selected_Item.GetComponent<Image>().color = color; //다른부분들 색 원래대로
            Description_Text.text = inventoryTabList[selectedItem].itemDescription;
            StartCoroutine(SelectedItemEffectCoroutine()); //선택된 곳만 반짝거리는 효과
        }
        else
            Description_Text.text = "해당 타입의 아이템을 소유하고 있지 않습니다.";
    }//선택된 아이템을 제외하고, 다른 모든 탭의 컬러 알파값을 0으로 조정.
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

            yield return new WaitForSeconds(0.3f); //반짝이고 잠시 지연
        }
    }//선택된 아이템 반작임 


    // Update is called once per frame
    void Update()
    {
        if(!stopKeyInput)
        {
            if(Input.GetKeyDown(KeyCode.I))//i키 누르면 인벤토리 열리게
            {
                activated = !activated;

                if(activated) //인벤토리 열릴때
                {
                    //theAudio.Play(open_sound);
                    //theOrder.NotMove();
                    go.SetActive(true);
                    selectedTab = 0;
                    tabActivated = true;
                    itemActivated = false;
                    ShowTab();
                }
                else //인벤토리 닫을때
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
                if(tabActivated) //탭이 활성화됏을때
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow)) //오른쪽키 눌렀을경우
                    {
                        if (selectedTab < selectedTabImages.Length - 1) //선택된 탭 이미지가 한칸오른쪽으로 이동
                            selectedTab++;
                        else //마지막 탭에서 오른쪽을 누르면 0번째로 돌아옴
                            selectedTab = 0;
                        //theAudio.Play(key_sound);
                        SelectedTab(); //선택된 탭 표시
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow)) //왼쪽키 눌렀을경우
                    {
                        if (selectedTab > 0) //선택된 탭 이미지가 한칸왼쪽으로 이동
                            selectedTab--;
                        else //첫번째 탭에서 왼쪽을 누르면 마지막으로
                            selectedTab = selectedTabImages.Length - 1;
                        //theAudio.Play(key_sound);
                        SelectedTab(); //선택된 탭 표시
                    }
                    else if (Input.GetKeyDown(KeyCode.Z)) //결정키를 눌렀을때 (임의로 Z를 눌렀을때로)
                    {
                        //theAudio.Play(enter_sound);
                        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
                        color.a = 0.25f;
                        selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                        itemActivated = true;
                        tabActivated = false;
                        preventExec = true; //탭과 인벤토리가 같이실행되지 않도록 하는 역할
                        ShowItem();
                    }
                } //탭 활성화시 키 입력 처리

                else if(itemActivated)
                {
                    if (inventoryTabList.Count > 0)
                    {
                        if (Input.GetKeyDown(KeyCode.DownArrow)) //아래키 누를시 +3(한줄에 들어가는 슬롯수만큼 +)
                        {
                            if (selectedItem < inventoryTabList.Count - 2)
                                selectedItem += 2;
                            else
                                selectedItem %= 2;
                            //theAudio.Play(key_sound);
                            SelectedItem();
                        }
                        else if (Input.GetKeyDown(KeyCode.UpArrow)) //위키 누를시
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
                        else if (Input.GetKeyDown(KeyCode.Z) && !preventExec) //탭을 선택한후 그 안에서 또 Z눌렀을때
                        {
                            if (selectedTab == 0) //첫번째 탭
                            {
                                //theAudio.Play(enter_sound);
                                stopKeyInput = true; //다른 키 입력 막기

                                //반짝이는 효과 멈추고 진한색으로 고정해서 완전 선택된느낌으로 만들기
                                //사용하시겠습니까? 같은 선택지 호출                                   
                            }
                            else if (selectedTab == 1)
                            {
                                //두번째 탭에서 Z눌렀을때. 현재 아무기능없음
                            }
                            else
                            {
                                //세번째 탭에서 Z눌렀을때. 현재 아무기능없음
                            }
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.X)) //인벤토리에서 탭으로 뒤로가기
                    {
                        //theAudio.Play(cancel_sound);
                        StopAllCoroutines();
                        itemActivated = false;
                        tabActivated = true;
                        ShowTab();
                    }
                } //인벤토리 활성화시 키 입력 처리

                if (Input.GetKeyUp(KeyCode.Z)) //중복실행 방지
                    preventExec = false;                   
            }
        }
    }
}
