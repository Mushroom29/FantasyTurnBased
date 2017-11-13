using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    //public int columns = 8;
    //public int rows = 8;
    //public int mirrorDirection = 0; // 0 for x-axis, 1 for y-axis
    public GameObject[] grassTiles;
    public GameObject[] hillTiles;

    private Transform boardHolder;
    private int boardColumns;
    private int boardRows;

    //private List<Vector3> gridPositions = new List<Vector3>();


    //void InitializeBoardArray()
    //{
    //    gridPositions.Clear();
    //
    //    for (int x = 0; x < columns; x++)
    //    {
    //        for (int y = 0; y < rows; y++)
    //        {
    //
    //            gridPositions.Add(new Vector3(x, y, 0f));
    //        }
    //    }
    //}


    public void BoardSetup(List<List<TileProperty.ThingsOnTile>> boardArray)
    {
        boardHolder = new GameObject("Board").transform;

        foreach(List<TileProperty.ThingsOnTile> entryColumn in boardArray)
        {
            foreach (TileProperty.ThingsOnTile entry in entryColumn)
            {
                GameObject toInstantiate = grassTiles[Random.Range(0, grassTiles.Length)];

                if (entry.tileType == TileProperty.TileType.Hill)
                {
                    toInstantiate = hillTiles[Random.Range(0, hillTiles.Length)];
                }
                //else if (entry.tileType == TileProperty.TileType.Grass)
                //{
                //    toInstantiate = grassTiles[Random.Range(0, grassTiles.Length)];
                //}

                GameObject instance = Instantiate(toInstantiate, entry.vectorLocation, Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }

        //// first it does the left most column starting at the bottm
        //// then it goes from left to right
        //for (int x = 0; x < rows; x++)
        //{
        //    for (int y = 0; y < columns; y++)
        //    {
        //        GameObject toInstantiate = grassTiles[Random.Range(0, grassTiles.Length)];
        //
        //        // 50% chance of either tile type
        //        if (Random.Range(-1, 1) >= 0)
        //        {
        //            toInstantiate = hillTiles[Random.Range(0, hillTiles.Length)];
        //        }
        //
        //        GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        //
        //        instance.transform.SetParent(boardHolder);
        //    }
        //}

        //int children = boardHolder.childCount;
        //for (int i = 0; i < children; i++)
        //{
        //    print("Child " + i);
        //    print(boardHolder.GetChild(i));
        //}
        //print(boardHolder.GameObject);
        //// if we are doing x-axis mirroring
        //if (mirrorDirection == 0)
        //{
        //    //print("test 1");
        //    boardRows = rows * 2;
        //    boardColumns = columns;
        //    int i = 0;
        //    for (int x = boardRows; x > rows; x--)
        //    {
        //        //print("test 2");
        //        for (int y = 0; y < boardColumns; y++)
        //        {
        //            i++;
        //            //print("test");
        //            //GameObject toInstantiate = boardHolder.GetChild(i).GameObject;
        //            //GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        //            //instance.transform.SetParent(boardHolder);
        //        }
        //    }
        //
        //
        //
        //}
        //// else we are doing y-axis mirroring
        //else
        //{
        //    boardRows = rows;
        //    boardColumns = columns * 2;
        //}
    }

    //public void SetupScene()
    //{
    //    BoardSetup();
    //   // InitializeBoardArray();
    //}
}
