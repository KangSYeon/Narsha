using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDataParser : MonoBehaviour
{
    public ObjectData[] Parse(string _CSVFileName)
    {
        List<ObjectData> objectList = new List<ObjectData>(); // ��� ����Ʈ ����
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); //Resources ���� �ȿ� �ִ� CSV ���� ����

        // ���� �������� �� �پ� �ɰ� �� data�� �־���
        string[] data = csvData.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length;)
        {
            // �� ���� ',' �������� �ɰ� �� col�� �־���
            string[] col = data[i].Split(new char[] { ',' });

            ObjectData obj = new ObjectData(); //��� ����Ʈ ����

            obj.chapter = col[1];

            List<string> chapterList = new List<string>(); // ��� ����Ʈ ����
            List<string> objectNameList = new List<string>(); // �̺�Ʈ �ѹ� ����
            List<string> itemNameList = new List<string>();
            List<string> quantityList = new List<string>();
            List<string> ownList = new List<string>();
            List<string> explanationList = new List<string>();

            //List<string> SkipList = new List<string>(); // ���� �ǳ��� ��� �߰� ���ϸ� ������

            do
            {
                chapterList.Add(col[2]);    // ��� 
                objectNameList.Add(col[3]);  // �̺�Ʈ��ȣ 
                itemNameList.Add(col[4]);
                quantityList.Add(col[5]);
                ownList.Add(col[6]);
                //explanationList.Add(col[7]);


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


            obj.chapter = chapterList.ToArray();
            //obj.objectName = objectNameList.ToArray();
            obj.itemName = itemNameList.ToArray();
            obj.quantity = quantityList.ToArray();
            obj.own = ownList.ToArray();
            obj.explanation = explanationList.ToArray();


            objectList.Add(obj);


        }
        // �迭 ���·� ��ȯ
        return objectList.ToArray();
       }

        void Start()
        {
            Parse("ObjectDatabase");
        }

    }

