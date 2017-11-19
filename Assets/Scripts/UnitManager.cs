using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject humanObject;
    public GameObject orcObject;

    private Transform unitHolder;

    public void UnitSetup(List<List<TileProperty.ThingsOnTile>> boardArray)
    {
        unitHolder = new GameObject("Units").transform;

        foreach (List<TileProperty.ThingsOnTile> entryColumn in boardArray)
        {
            foreach (TileProperty.ThingsOnTile entry in entryColumn)
            {
                if (entry.unitType != TileProperty.UnitType.None)
                {
                    GameObject toInstantiate = humanObject;

                    if (entry.unitType == TileProperty.UnitType.Orc)
                    {
                        toInstantiate = orcObject;
                    }

                    GameObject instance = Instantiate(toInstantiate, entry.vectorLocation, Quaternion.identity) as GameObject;

                    instance.transform.SetParent(unitHolder);
                }
            }
        }
    }
}
