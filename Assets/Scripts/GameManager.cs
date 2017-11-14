using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //Allows us to use UI.

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public List<List<TileProperty.ThingsOnTile>> boardArray = new List<List<TileProperty.ThingsOnTile>>();
    public int columns = 8;
    public int rows = 8;
    public int percentHill = 40;

    private BoardManager boardScript;
    private BoardArray arrayScript;

    //private bool doingSetup = true;

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
        arrayScript = GetComponent<BoardArray>();
        InitGame();
    }

    void InitGame()
    {
        //doingSetup = true;

        arrayScript.InitializeBoardArray(boardArray, columns, rows, true, false, percentHill);
        boardScript.BoardSetup(boardArray);
    }
}
