using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeMap : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase asd;

    // Start is called before the first frame update
    void Start()
    {
        tileMap = FindObjectOfType<Tilemap>();



        BoundsInt bounds = tileMap.cellBounds;

        TileBase[] allTiles = tileMap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    tileMap.SetTile(new Vector3Int(x + bounds.xMin,y + bounds.yMin,0), asd);
                    Sprite dd = tileMap.GetSprite(new Vector3Int(x + bounds.xMin, y + bounds.yMin, 0));
                    Debug.Log("X : " + x + " Y: " + y + " Tile : " + tile.name);
                }
                else
                {
                    Debug.Log("X : " + x + " Y: " + y + " Tile : (null)");
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
