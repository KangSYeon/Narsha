using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // 대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //Resources 폴더 안에 있는 CSV 파일 기재

        // 엔터 기준으로 한 줄씩 쪼갠 걸 data에 넣어줌
        string[] data = csvData.text.Split(new char[] { '\n' });
        
        for(int i=1; i<data.Length;)
        {
            // 한 줄을 ',' 기준으로 쪼갠 걸 col에 넣어줌
            string[] col = data[i].Split(new char[] { ',' });

            Dialogue dialogue = new Dialogue(); //대사 리스트 생성

            dialogue.name = col[1];

            List<string> contextList = new List<string>(); // 대사 리스트 생성
            List<string> EventList = new List<string>(); // 이벤트 넘버 생성
            List<string> portraitList = new List<string>(); 
            List<string> positionList = new List<string>(); 
            List<string> SkipList = new List<string>(); 
            List<string> popList = new List<string>(); 

            //List<string> SkipList = new List<string>(); // 엑셀 맨끝줄 비고 추가 안하면 오류남

            do
            {
                contextList.Add(col[2]);    // 대사 
                EventList.Add(col[3]);  // 이벤트번호 
                portraitList.Add(col[4]);
                positionList.Add(col[5]);
                SkipList.Add(col[6]);
                //popList.Add(col[7]);


                // 한 행을 한 줄씩 콘솔창에 보여주기
                Debug.Log(col[3]);

                if (++i < data.Length) // i가 미리 증가한 상태에서 비교해준다 dataLentg보다 작다면
                {
                    col = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }

            } while (col[0].ToString() == "");// 최초 1회 조건 비교 없이 한 차례 실행시키고 조건문을 비교
                                                      // row 0번째 줄에는 대사번호가 들어가 있고 Tostring으로 빈 공간인지 비교해줌


            dialogue.contexts = contextList.ToArray();
            dialogue.eventNum = EventList.ToArray();
            dialogue.portraitNum = portraitList.ToArray();
            dialogue.position = positionList.ToArray();
            dialogue.skipNum = SkipList.ToArray();
            dialogue.popNum = popList.ToArray();


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
