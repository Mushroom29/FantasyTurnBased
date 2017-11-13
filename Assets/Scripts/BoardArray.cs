using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardArray : MonoBehaviour
{
    public int columns = 8;
    public int rows = 8;
    //static TileProperty.ThingsOnTile[][] boardArray;
    static TileProperty.ThingsOnTile[][] boardArray = new TileProperty.ThingsOnTile[8][8];
    //int[] testArray = new int[8];

    void SizeBoardArray(int x, int y)
    {
        boardArray[0][0] = new TileProperty.ThingsOnTile();
        //TileProperty.ThingsOnTile[0][0] = new TileProperty.ThingsOnTile();
        //testArray[0] = 1;
    }

    void InitializeBoardArray()
    {
        print(boardArray[0][0].tileType);
        //print(boardArray.tileType);
        //print(boardArray.resourceType);
        //print(testArray[0]);
        // gridPositions.Clear();
        //
        // for (int x = 0; x < columns; x++)
        // {
        //     for (int y = 0; y < rows; y++)
        //     {
        //
        //         gridPositions.Add(new Vector3(x, y, 0f));
        //     }
        // }
    }


    public void SetupArray()
    {
        SizeBoardArray(rows, columns);
        InitializeBoardArray();
    }
}
