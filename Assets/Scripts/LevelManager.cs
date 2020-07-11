using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Tilemap map = null;
    [SerializeField] private Tilemap flagMap = null;
    private List<Vector2Int> _flags = new List<Vector2Int>();

    public Tilemap Map => map;

    private void Start()
    {
        //todo save state of controls here for soft reset
        //resets tilemap bounds in case someone messed up while editing one
        map.CompressBounds();
        flagMap.CompressBounds();
        BoundsInt boundsFlag = flagMap.cellBounds;
        TileBase[] allTilesFlag = flagMap.GetTilesBlock(boundsFlag);

        for (int x = 0; x < boundsFlag.size.x; x++)
        {
            for (int y = 0; y < boundsFlag.size.y; y++)
            {
                TileBase tile = allTilesFlag[x + y * boundsFlag.size.x];
                if (tile != null)
                {
                    _flags.Add(new Vector2Int( + boundsFlag.position.x, y + boundsFlag.position.y));
                }
            }
        }
    }

    //Returns true if all flags have a box on them
    public bool CheckFlags()
    {
        foreach (var flagPos in _flags)
        {
            if (!map.HasTile((Vector3Int) flagPos))
            {
                return false;
            }
        }

        return true;
    }
}