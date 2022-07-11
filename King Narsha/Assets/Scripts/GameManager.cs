using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Game 어디서든 grab it 하기 위해 instance 생성 : static
    public static GameManager GetInstance() { Init(); return Instance; }
    public GameState State;

    void Awake()
    {
        Instance = this; //게임을 시작할 때 게임 매니저 불러오기
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        //switch -> tab -> 변수명 -> tab 시 case 자동완성
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
    //게임의 상태를 결정하는 모든 요소를 나열하면 됩니다. (enum)
    //Example, 저희 게임에는 광기라는 상태가 있습니다. 광기의 변수명은 Madness로 하겠습니다. 아래는 Example입니다.
    //Madness,
    //NormalGame,
    //ErrorGame
}
