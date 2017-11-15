using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    private GameObject mainCamera;
    //private int TilePixelLength = 32;

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

        print(boardWidth / boardHeight);
        print(screenWidth / screenHeight);

        // 2 ways we need to determine the camera by whatever dimension is the limiting factor
        // Compare the aspect ratio of the game board to the game display to determine tile resolution
        if((boardWidth / boardHeight) > (screenWidth / screenHeight))
        {
            // The board width is limited so it will determine tile resolution
            //screenWidth / boardWidth

            //   (screenWidth / screenHeight ) * boardHeight

            //newOrthographicSize = ((screenWidth / screenHeight) * (boardWidth / (boardHeight * (float)2))); // 4.32
            //newOrthographicSize = (((boardHeight / (float)2) * (boardWidth / (boardHeight))) / (screenWidth / screenHeight));
            newOrthographicSize = ((boardWidth / (float) 2) * (screenHeight / screenWidth));
            newYPosition = ((boardHeight / (float)2) - (float)0.5);
            newXPosition = ((boardWidth / (float)2) - (float)0.5);

            print("Width fill");
        }
        // 
        else
        {
            // The board height is limited so it will determine tile resolution
            newOrthographicSize = (boardHeight / (float)2);
            newYPosition = (newOrthographicSize - (float)0.5);
            newXPosition = ((boardWidth / (float)2) - (float)0.5);

            print("Height fill");
        }

        mainCamera.transform.position = new Vector3(newXPosition, newYPosition, -10f);
        mainCamera.GetComponent<Camera>().orthographicSize = newOrthographicSize;

        print(boardWidth + " -> " + newOrthographicSize);
        print(boardHeight + " -> " + (screenWidth / screenHeight));
        
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
