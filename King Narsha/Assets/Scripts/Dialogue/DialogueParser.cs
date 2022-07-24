using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // 대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //CSV 파일 기재

        // 엔터 기준으로 한 줄씩 쪼갠 걸 data에 넣어줌
        string[] data = csvData.text.Split(new char[] { '\n' });
        
        for(int i=1; i<data.Length;)
        {
            // 한 줄을 ',' 기준으로 쪼갠 걸 row에 넣어줌
            string[] row = data[i].Split(new char[] { ',' });

            Dialogue dialogue = new Dialogue(); //대사 리스트 생성

            dialogue.name = row[1];

            List<string> contextList = new List<string>();

            do {
                contextList.Add(row[2]);

                // 대사 한 줄씩 콘솔창에 보여주기
                Debug.Log(row[2]);

                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }

            } while (row[0].ToString() == "");

            dialogue.contexts = contextList.ToArray();

            dialogueList.Add(dialogue);
        }
        // 배열 형태로 반환
        return dialogueList.ToArray();
    }

    void Start()
    {
        Parse("MyText");
    }
}
