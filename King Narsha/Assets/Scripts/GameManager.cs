<<<<<<< HEAD
ï»¿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Game ï¿½ï¿½ğ¼­µï¿½ grab it ï¿½Ï±ï¿½ ï¿½ï¿½ï¿½ï¿½ instance ï¿½ï¿½ï¿½ï¿½ : static
    public static GameManager GetInstance() { Init(); return Instance; }
    public GameState State;

    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public Image portraitImg;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;

    public TextAsset txt;
    string[,] Sentence;
    int lineSize, rowSize;


    void Awake()
    {
        Instance = this; //ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½Å´ï¿½ï¿½ï¿½ ï¿½Ò·ï¿½ï¿½ï¿½ï¿½ï¿½
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //Game ¾îµğ¼­µç grab it ÇÏ±â À§ÇØ instance »ı¼º : static
    public static GameManager GetInstance() { Init(); return Instance; }
    public GameState State;

    void Awake()
    {
        Instance = this; //°ÔÀÓÀ» ½ÃÀÛÇÒ ¶§ °ÔÀÓ ¸Å´ÏÀú ºÒ·¯¿À±â
>>>>>>> origin/ë¯¼ì§€ë‹˜-Merge
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

<<<<<<< HEAD
        //switch -> tab -> ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ -> tab ï¿½ï¿½ case ï¿½Úµï¿½ï¿½Ï¼ï¿½
=======
        //switch -> tab -> º¯¼ö¸í -> tab ½Ã case ÀÚµ¿¿Ï¼º
>>>>>>> origin/ë¯¼ì§€ë‹˜-Merge
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


<<<<<<< HEAD


    public void Action(GameObject scanObj)
    {
        if (isAction)   // ì‹¤í–‰ ì¤‘ì´ ì•„ë‹ ë•Œ ëŒ€í™”ì°½ ì—†ì• ê¸°
        {
            isAction = false;
        }
        else    // ì‹¤í–‰ ì¤‘ì¼ ë•Œ ëŒ€í™”ì°½ ë„ìš°ê¸°
        {
            isAction = true;
            scanObject = scanObj;

            // ìŠ¤ìº”í•œ ì˜¤ë¸Œì íŠ¸ì˜ idì™€ isNPC ì •ë³´ë¥¼ ê°€ì ¸ì™€ì•¼ í•˜ê¸° ë•Œë¬¸ì— objData scriptê°€ í•„ìš”
            ObjData objData = scanObject.GetComponent<ObjData>();
            // objDataì˜ idì™€ NPCì¸ì§€ ì •ë³´ë¥¼ ë§¤ê°œë³€ìˆ˜ë¡œ ë„˜ê¹€
            Talk(objData.id, objData.isNPC);

        }
        talkPanel.SetActive(isAction);  // ëŒ€í™”ì°½ í™œì„±í™” ìƒíƒœì— ë”°ë¼ ëŒ€í™”ì°½ í™œì„±í™” ë³€ê²½
    }

    // ì‹¤ì œ ëŒ€ì‚¬ë“¤ì„ UIì— ì¶œë ¥í•˜ëŠ” í•¨ìˆ˜
    void Talk(int id, bool isNPC)
    {
        // talkMangerì— ìƒì„±í•œ ëŒ€ì‚¬ë¥¼ ë°˜í™˜í•˜ëŠ” í•¨ìˆ˜ë¥¼ ì´ìš©í•˜ì—¬ ëŒ€ì‚¬ í•œ ì¤„ì„ ì…ë ¥ë°›ìŒ
        string talkData = talkManager.GetTalk(id, talkIndex);

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        // ì…ë ¥ë°›ì€ ëŒ€ì‚¬ë¥¼ ì´ìš©í•˜ì—¬ ì¶œë ¥
        if (isNPC)
        {
            talkText.text = talkData.Split(':')[0];

            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[0]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;
            // NPCê°€ ì•„ë‹ ê²½ìš° ì•ˆ ë³´ì´ë„ë¡ ìƒ‰ ì¡°ì •
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    void Start()
    {
        // ì—”í„° ë‹¨ìœ„ì™€ íƒ­ìœ¼ë¡œ ë‚˜ëˆ ì„œ ë°°ì—´ì˜ í¬ê¸° ì¡°ì ˆ
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        print(currentText);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        Sentence = new string[lineSize, rowSize];

        // í•œ ì¤„ì—ì„œ íƒ­ìœ¼ë¡œ ë‚˜ëˆ”
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for(int j=0; j<rowSize; j++)
            {
                Sentence[i, j] = row[j];
            }
        }
    }

=======
>>>>>>> origin/ë¯¼ì§€ë‹˜-Merge
}

public enum GameState
{
<<<<<<< HEAD
    //ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½Â¸ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ï´ï¿½ ï¿½ï¿½ï¿½ ï¿½ï¿½Ò¸ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½Ï¸ï¿½ ï¿½Ë´Ï´ï¿½. (enum)
    //Example, ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½Ó¿ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½Â°ï¿½ ï¿½Ö½ï¿½ï¿½Ï´ï¿½. ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ Madnessï¿½ï¿½ ï¿½Ï°Ú½ï¿½ï¿½Ï´ï¿½. ï¿½Æ·ï¿½ï¿½ï¿½ Exampleï¿½Ô´Ï´ï¿½.
=======
    //°ÔÀÓÀÇ »óÅÂ¸¦ °áÁ¤ÇÏ´Â ¸ğµç ¿ä¼Ò¸¦ ³ª¿­ÇÏ¸é µË´Ï´Ù. (enum)
    //Example, ÀúÈñ °ÔÀÓ¿¡´Â ±¤±â¶ó´Â »óÅÂ°¡ ÀÖ½À´Ï´Ù. ±¤±âÀÇ º¯¼ö¸íÀº Madness·Î ÇÏ°Ú½À´Ï´Ù. ¾Æ·¡´Â ExampleÀÔ´Ï´Ù.
>>>>>>> origin/ë¯¼ì§€ë‹˜-Merge
    //Madness,
    //NormalGame,
    //ErrorGame
}
<<<<<<< HEAD

=======
>>>>>>> origin/ë¯¼ì§€ë‹˜-Merge
