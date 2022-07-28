using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �ʻ�ȭ ��� ����
// ��� ��� ����
public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] porArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();

        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1, new string[] { "�̰� �ɺ��̴�" });
        talkData.Add(2, new string[] { "������Ʈ��" });

        talkData.Add(1000, new string[] { "�ȳ�: 0", "���� NPC��: 1" });
        talkData.Add(1001, new string[] { "������ ����: 0" });


        portraitData.Add(1000 + 0, porArr[0]);
        portraitData.Add(1000 + 1, porArr[1]);
        portraitData.Add(1000 + 2, porArr[2]);
        portraitData.Add(1000 + 3, porArr[3]);
        portraitData.Add(1000 + 4, porArr[4]);
        portraitData.Add(1000 + 5, porArr[5]);

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}