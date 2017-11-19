using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public GameObject[] grassTiles;
    public GameObject[] hillTiles;

    private Transform boardHolder;

    public void BoardSetup(List<List<TileProperty.ThingsOnTile>> boardArray)
    {
        boardHolder = new GameObject("Board").transform;

        foreach (List<TileProperty.ThingsOnTile> entryColumn in boardArray)
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
    }
}
