using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileProperty
{
    public enum TileType { Grass, Hill };
    public enum ResourceType { None, Mineral, Sheep };

    public class ThingsOnTile
    {
        public Vector3 vectorLocation;
        public TileType tileType;
        public ResourceType resourceType;

        public ThingsOnTile(Vector3 loc, TileType tile, ResourceType res)
        {
            vectorLocation = loc;
            tileType = tile;
            resourceType = res;
        }
    }
}
