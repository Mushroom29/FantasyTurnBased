using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardArray : MonoBehaviour
{
    // create base array size
    void CreateBaseBoardArray (List<List<TileProperty.ThingsOnTile>> boardArray, int rows, int columns)
    {
        for (int x = 0; x < columns; x++)
        {
            boardArray.Add(new List<TileProperty.ThingsOnTile>());
            for (int y = 0; y < rows; y++)
            {
                boardArray[x].Add(new TileProperty.ThingsOnTile(new Vector3(x, y, 0f), TileProperty.TileType.Grass, TileProperty.ResourceType.None));
            }
        }
    }

    // populate tile types
    void PopulateTiles(List<List<TileProperty.ThingsOnTile>> boardArray, int percentHill)
    {
        foreach (List<TileProperty.ThingsOnTile> entryColumn in boardArray)
        {
            foreach (TileProperty.ThingsOnTile entry in entryColumn)
            {
                if (Random.Range(0, 100) <= percentHill)
                {
                    entry.tileType = TileProperty.TileType.Hill;
                }
                else
                {
                    entry.tileType = TileProperty.TileType.Grass;
                }
            }
        }
    }


    // populate resources


    // Mirror the board across the x axis
    //369
    //258 - addition
    //147
    //---
    //147
    //258 - original
    //369
    void MirrorOverXAxis(List<List<TileProperty.ThingsOnTile>> boardArray)
    {
        for (int x = 0; x < boardArray.Count; x++)
        {
            int yVectorAdd = 1;
            for (int y = boardArray[x].Count - 1; y > -1; y--)
            {
                boardArray[x].Add(new TileProperty.ThingsOnTile(new Vector3(x, (y + yVectorAdd), 0f), boardArray[x][y].tileType, boardArray[x][y].resourceType));
                yVectorAdd = yVectorAdd + 2;
            }
        }
    }

    // Mirror the board across the y axis
    //  __original
    //  |   __addition
    // 963|369
    // 852|258
    // 741|147
    void MirrorOverYAxis(List<List<TileProperty.ThingsOnTile>> boardArray)
    {
        int xMirrorIndex = boardArray.Count;

        for (int x = boardArray.Count - 1; x > -1; x--)
        {
            // add a new column
            boardArray.Add(new List<TileProperty.ThingsOnTile>());
            for (int y = 0; y < boardArray[x].Count; y++)
            {
                boardArray[xMirrorIndex].Add(new TileProperty.ThingsOnTile(new Vector3((xMirrorIndex), y, 0f), boardArray[x][y].tileType, boardArray[x][y].resourceType));
            }

            // increment the x index in preparation of the next column being added
            xMirrorIndex++;
        }
    }

    public void InitializeBoardArray(List<List<TileProperty.ThingsOnTile>> boardArray, int rows, int columns, bool xMirror, bool yMirror, int percentHill)
    {
        CreateBaseBoardArray(boardArray, rows, columns);
        PopulateTiles(boardArray, percentHill);

        if(xMirror)
        {
            MirrorOverXAxis(boardArray);
        }
        if(yMirror)
        {
            MirrorOverYAxis(boardArray);
        }
    }
}
