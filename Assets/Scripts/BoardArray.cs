using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardArray : MonoBehaviour
{
    private List<Vector3> gridPositions = new List<Vector3>();

    // create base array size
    void CreateBaseBoardArray (List<List<TileProperty.ThingsOnTile>> boardArray, int rows, int columns)
    {
        gridPositions.Clear();

        for (int x = 0; x < columns; x++)
        {
            boardArray.Add(new List<TileProperty.ThingsOnTile>());
            for (int y = 0; y < rows; y++)
            {
                boardArray[x].Add(new TileProperty.ThingsOnTile(new Vector3(x, y, 0f), TileProperty.TileType.Grass, TileProperty.ResourceType.None));

                // Add positions for unit placement
                gridPositions.Add(new Vector3(x, y, 0f));
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


    Vector3 ExclusiveUnitPosition()
    {
        int randomIndex = Random.Range(0, gridPositions.Count);
        Vector3 randomPosition = gridPositions[randomIndex];
        gridPositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObjectAtRandom(List<List<TileProperty.ThingsOnTile>> boardArray, TileProperty.UnitType unitTypeToAdd, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = ExclusiveUnitPosition();
            foreach (List<TileProperty.ThingsOnTile> entryColumn in boardArray)
            {
                foreach (TileProperty.ThingsOnTile entry in entryColumn)
                {
                    if (entry.vectorLocation == randomPosition)
                    {
                        entry.unitType = unitTypeToAdd;
                    }
                }
            }
        }
    }




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
                boardArray[x].Add(new TileProperty.ThingsOnTile(new Vector3(x, (y + yVectorAdd), 0f), boardArray[x][y].tileType, boardArray[x][y].resourceType, boardArray[x][y].unitType));
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
                boardArray[xMirrorIndex].Add(new TileProperty.ThingsOnTile(new Vector3((xMirrorIndex), y, 0f), boardArray[x][y].tileType, boardArray[x][y].resourceType, boardArray[x][y].unitType));
            }

            // increment the x index in preparation of the next column being added
            xMirrorIndex++;
        }
    }

    public void InitializeBoardArray(List<List<TileProperty.ThingsOnTile>> boardArray, int rows, int columns, bool xMirror, bool yMirror, int percentHill, int startingHumansMin, int startingHumansMax, int startingOrcsMin, int startingOrcsMax)
    {
        CreateBaseBoardArray(boardArray, rows, columns);
        PopulateTiles(boardArray, percentHill);
        LayoutObjectAtRandom(boardArray, TileProperty.UnitType.Human, startingHumansMin, startingHumansMax);
        LayoutObjectAtRandom(boardArray, TileProperty.UnitType.Orc, startingOrcsMin, startingOrcsMax);

        if (xMirror)
        {
            MirrorOverXAxis(boardArray);
        }
        if (yMirror)
        {
            MirrorOverYAxis(boardArray);
        }
    }
}
