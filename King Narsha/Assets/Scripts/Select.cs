using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

//���� ���۽� ������ ������ ������ �� �ְ��ϴ� ���


public class Select : MonoBehaviour
{
    public GameObject creat; // �󽽷� Ŭ���� �ߴ� â
    public Text[] slotText; //����ĭ�� �� �ؽ�Ʈ�� ���� �迭
    public Text newPlayerName; //���ο� �÷��̾��̸�

    bool[] savefile = new bool[3]; //���Կ� ���̺������� �����ϴ��� ����

    // Start is called before the first frame update
    void Start()
    {
        //���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}")) //���̺������� �����Ѵٸ�
            {
                savefile[i] = true; //���̺����� ���翩�θ� true�� ����
                DataManager.instance.nowSlot = i; 
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.name; //�����̸��� �÷��̾��̸����� ���� + ���� ����ð��̳� �����Ȳ ������� ���Կ� ǥ���Ϸ��� ���� �����ߴٰ� �̺κп� �߰�
            }
            else 
            {
                slotText[i].text = "�������";
            }
        }
        DataManager.instance.DataClear();//�ҷ��� ������ Ŭ����
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;
     
        if (savefile[number])// ����� �����Ͱ� ������
        {
            DataManager.instance.LoadData(); //������ �ҷ�����
            GoGame(); // ���Ӿ����� �̵�
        }
        else // ����� �����Ͱ� ������
        {
             Creat();
        }
    }

    public void Creat()
    {
        creat.gameObject.SetActive(true); //�󽽷� Ŭ���� �ߴ� â ����
    }

    public void GoGame() //���Ӿ����� �̵�
    {
        if (!savefile[DataManager.instance.nowSlot]) //����� �����Ͱ� ���� ��
        {
            DataManager.instance.nowPlayer.name = newPlayerName.text; //�Է��� �̸��� �޾ƿͼ� nowPlayer�̸��� ����
            DataManager.instance.SaveData(); //������ ����
        }
       

        SceneManager.LoadScene(1); // ���Ӿ� �����Է�
    }
}