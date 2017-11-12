using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //Allows us to use UI.

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public BoardManager boardScript;
    public CameraManager cameraScript;

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
        cameraScript = GetComponent<CameraManager>();
        InitGame();
    }

    void InitGame()
    {
        doingSetup = true;

        boardScript.SetupScene();
    }
}
