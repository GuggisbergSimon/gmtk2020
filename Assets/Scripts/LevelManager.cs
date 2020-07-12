using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Tilemap map = null;
    [SerializeField] private Tilemap flagMap = null;
    private List<Vector3Int> _flags = new List<Vector3Int>();

    public Tilemap Map => map;

    private void Start()
    {
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
                    _flags.Add(new Vector3Int(x + boundsFlag.position.x, y + boundsFlag.position.y, 0));
                }
            }
        }
    }

    //Returns true if all flags have a box on them
    public bool CheckFlags()
    {
        foreach (var flagPos in _flags)
        {
            if (!map.HasTile(flagPos))
            {
                return false;
            }
        }

        return true;
    }
}