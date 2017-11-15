using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    private GameObject mainCamera;
    private int TilePixelLength = 32;

    public void CameraSetup(List<List<TileProperty.ThingsOnTile>> boardArray)
    {        
        mainCamera = GameObject.Find("Main Camera");

        float boardWidth = boardArray.Count;
        float boardHeight = boardArray[0].Count;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float newOrthographicSize = 1f;
        float newXPosition = 0f;
        float newYPosition = 0f;

        // 2 ways we need to determine the camera by whatever dimension is the limiting factor
        // if the x resolution is limiting

        // else the y resolution is limiting
        newOrthographicSize = (boardHeight / (float)2);
        newYPosition = (newOrthographicSize - (float)0.5);
        newXPosition = ((boardWidth / (float)2) - (float)0.5);

        mainCamera.transform.position = new Vector3(newXPosition, newYPosition, -10f);
        mainCamera.GetComponent<Camera>().orthographicSize = newOrthographicSize;

        print(boardWidth + " -> " + (Screen.width));
        print(boardHeight + " -> " + (Screen.height / boardHeight));

        print(screenWidth);
        print(screenHeight);

        //The orthographic size expresses how many world units are contained in the top half of the camera projection.
        //For example, if you set an orthographic size of 5, then the vertical extents of the viewport will contain exactly 10 units of world space.

        // Po x - 3
        // Po y - 5.5
        // Size - 6
        // Ti x - 7
        // Ti y - 12
        // Di x - 475
        // Di y - 514
    }
}
