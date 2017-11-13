using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardArray : MonoBehaviour
{
    //public static int columns = 8;
    //public static int rows = 8;
    public int percentHill = 40;

    //public List<List<TileProperty.ThingsOnTile>> boardArray = new List<List<TileProperty.ThingsOnTile>> ();

    public void InitializeBoardArray(List<List<TileProperty.ThingsOnTile>> boardArray, int rows, int columns)
    {
        for (int x = 0; x < columns; x++)
        {
            boardArray.Add(new List<TileProperty.ThingsOnTile>());

            for (int y = 0; y < rows; y++)
            {
                TileProperty.ThingsOnTile temp;

                if (Random.Range(0, 100) <= percentHill)
                {
                    temp = new TileProperty.ThingsOnTile(new Vector3(x, y, 0f), TileProperty.TileType.Hill, TileProperty.ResourceType.Mineral);
                    boardArray[x].Add(temp);
                    //print("hill");
                }
                else
                {
                    temp = new TileProperty.ThingsOnTile(new Vector3(x, y, 0f), TileProperty.TileType.Grass, TileProperty.ResourceType.None);
                    boardArray[x].Add(temp);
                    //print("grass");
                }
            }
        }
    }


    //public TileProperty.ThingsOnTile[,] boardArray = new TileProperty.ThingsOnTile[rows, columns];
    //
    //void InitializeBoardArray()
    //{
    //    for (int x = 0; x < columns; x++)
    //    {
    //        for (int y = 0; y < rows; y++)
    //        {
    //            if (Random.Range(0, 100) <= percentHill)
    //            {
    //                boardArray[x, y] = new TileProperty.ThingsOnTile(TileProperty.TileType.Hill, TileProperty.ResourceType.Mineral);
    //                print("hill");
    //            }
    //            else
    //            {
    //                boardArray[x, y] = new TileProperty.ThingsOnTile();
    //                print("grass");
    //            }
    //        }
    //    }
    //}


    //public void SetupArray()
    //{
    //    InitializeBoardArray();
    //}
}
