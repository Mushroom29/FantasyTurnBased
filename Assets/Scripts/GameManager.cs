using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //Allows us to use UI.

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private BoardManager boardScript;
    private BoardArray arrayScript;

    private bool doingSetup = true;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        boardScript = GetComponent<BoardManager>();
        //print(boardScript);
        arrayScript = GameObject.Find("BoardArray").GetComponent<BoardArray>();
        //print(arrayScript);
        InitGame();
    }

    void InitGame()
    {
        doingSetup = true;

        boardScript.SetupScene();
        arrayScript.SetupArray();
    }
}
