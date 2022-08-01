using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // ��� ����Ʈ ����
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //Resources ���� �ȿ� �ִ� CSV ���� ����

        // ���� �������� �� �پ� �ɰ� �� data�� �־���
        string[] data = csvData.text.Split(new char[] { '\n' });
        
        for(int i=1; i<data.Length;)
        {
            // �� ���� ',' �������� �ɰ� �� col�� �־���
            string[] col = data[i].Split(new char[] { ',' });

            Dialogue dialogue = new Dialogue(); //��� ����Ʈ ����

            dialogue.name = col[1];

            List<string> contextList = new List<string>(); // ��� ����Ʈ ����
            List<string> EventList = new List<string>(); // �̺�Ʈ �ѹ� ����
            List<string> portraitList = new List<string>(); 
            List<string> positionList = new List<string>(); 
            List<string> SkipList = new List<string>(); 
            List<string> popList = new List<string>(); 

            //List<string> SkipList = new List<string>(); // ���� �ǳ��� ��� �߰� ���ϸ� ������

            do
            {
                contextList.Add(col[2]);    // ��� 
                EventList.Add(col[3]);  // �̺�Ʈ��ȣ 
                portraitList.Add(col[4]);
                positionList.Add(col[5]);
                SkipList.Add(col[6]);
                //popList.Add(col[7]);


                // �� ���� �� �پ� �ܼ�â�� �����ֱ�
                Debug.Log(col[3]);

                if (++i < data.Length) // i�� �̸� ������ ���¿��� �����ش� dataLentg���� �۴ٸ�
                {
                    col = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }

            } while (col[0].ToString() == "");// ���� 1ȸ ���� �� ���� �� ���� �����Ű�� ���ǹ��� ��
                                                      // row 0��° �ٿ��� ����ȣ�� �� �ְ� Tostring���� �� �������� ������


            dialogue.contexts = contextList.ToArray();
            dialogue.eventNum = EventList.ToArray();
            dialogue.portraitNum = portraitList.ToArray();
            dialogue.position = positionList.ToArray();
            dialogue.skipNum = SkipList.ToArray();
            dialogue.popNum = popList.ToArray();


            dialogueList.Add(dialogue);


        }
        // �迭 ���·� ��ȯ
        return dialogueList.ToArray();



    }

    void Start()
    {
        Parse("MyText");
    }

}
