using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardArray : MonoBehaviour
{
    public int percentHill = 40;

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
}
