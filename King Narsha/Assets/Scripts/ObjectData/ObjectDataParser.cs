using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDataParser : MonoBehaviour
{
    public ObjectData[] Parse(string _CSVFileName)
    {
        List<ObjectData> objectList = new List<ObjectData>(); // 대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //Resources 폴더 안에 있는 CSV 파일 기재

        // 엔터 기준으로 한 줄씩 쪼갠 걸 data에 넣어줌
        string[] data = csvData.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length;)
        {
            // 한 줄을 ',' 기준으로 쪼갠 걸 col에 넣어줌
            string[] col = data[i].Split(new char[] { ',' });

            ObjectData obj = new ObjectData(); //대사 리스트 생성

            obj.chapter = col[1];

            List<string> chapterList = new List<string>(); // 대사 리스트 생성
            List<string> objectNameList = new List<string>(); // 이벤트 넘버 생성
            List<string> itemNameList = new List<string>();
            List<string> quantityList = new List<string>();
            List<string> ownList = new List<string>();
            List<string> explanationList = new List<string>();

            //List<string> SkipList = new List<string>(); // 엑셀 맨끝줄 비고 추가 안하면 오류남

            do
            {
                chapterList.Add(col[2]);    // 대사 
                objectNameList.Add(col[3]);  // 이벤트번호 
                itemNameList.Add(col[4]);
                quantityList.Add(col[5]);
                ownList.Add(col[6]);
                //explanationList.Add(col[7]);


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


            obj.chapter = chapterList.ToArray();
            //obj.objectName = objectNameList.ToArray();
            obj.itemName = itemNameList.ToArray();
            obj.quantity = quantityList.ToArray();
            obj.own = ownList.ToArray();
            obj.explanation = explanationList.ToArray();


            objectList.Add(obj);


        }
        // 배열 형태로 반환
        return objectList.ToArray();
       }

        void Start()
        {
            Parse("ObjectDatabase");
        }

    }

