using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProperty : MonoBehaviour
{
    public enum TileType { Grass, Hill };
    public enum ResourceType { None, Mineral, Sheep };

    public class ThingsOnTile
    {
        public TileType tileType;
        public ResourceType resourceType;

        public ThingsOnTile(TileType tile, ResourceType res)
        {
            tileType = tile;
            resourceType = res;
        }

        public ThingsOnTile()
        {
            tileType = TileType.Grass;
            resourceType = ResourceType.None;
        }
    }

}
