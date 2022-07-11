using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Game ��𼭵� grab it �ϱ� ���� instance ���� : static
    public static GameManager GetInstance() { Init(); return Instance; }
    public GameState State;

    void Awake()
    {
        Instance = this; //������ ������ �� ���� �Ŵ��� �ҷ�����
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        //switch -> tab -> ������ -> tab �� case �ڵ��ϼ�
        /*switch (newState)
        {
        }*/
    }

    static void Init()
    {
        if (Instance == null)
        {
            GameObject go = GameObject.Find("@GameManager");
            if (go == null)
            {
                go = new GameObject { name = "@GameManager" };
                go.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(go);
            Instance = go.GetComponent<GameManager>();
        }
    }


}

public enum GameState
{
    //������ ���¸� �����ϴ� ��� ��Ҹ� �����ϸ� �˴ϴ�. (enum)
    //Example, ���� ���ӿ��� ������ ���°� �ֽ��ϴ�. ������ �������� Madness�� �ϰڽ��ϴ�. �Ʒ��� Example�Դϴ�.
    //Madness,
    //NormalGame,
    //ErrorGame
}
