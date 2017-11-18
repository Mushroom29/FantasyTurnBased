using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileProperty
{
    public enum TileType { Grass, Hill };
    public enum ResourceType { None, Mineral, Sheep };
    public enum UnitType { None, Human, Orc };

    public class ThingsOnTile
    {
        public Vector3 vectorLocation;
        public TileType tileType;
        public ResourceType resourceType;
        public UnitType unitType;

        public ThingsOnTile(Vector3 loc, TileType tile, ResourceType res)
        {
            vectorLocation = loc;
            tileType = tile;
            resourceType = res;
        }

        public ThingsOnTile(Vector3 loc, TileType tile, ResourceType res, UnitType unit)
        {
            vectorLocation = loc;
            tileType = tile;
            resourceType = res;
            unitType = unit;
        }

        public ThingsOnTile()
        {
            vectorLocation = new Vector3(0, 0, 0f);
            tileType = TileProperty.TileType.Grass;
            resourceType = TileProperty.ResourceType.None;
            unitType = TileProperty.UnitType.None;
        }
    }
}
