using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 대사에 따라 초상화 변경
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
        talkData.Add(1, new string[] { "이건 꽃병이다" });

        // 구분자 ":"와 함께 초상화의 인덱스를 설정하여 문장마다 NPC의 표정 바꿀 수 있음
        talkData.Add(1000, new string[] { "안녕: 0", "안녕??: 1" });

        // NPC의 id를 1000번 이상으로 설정해뒀음.
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
