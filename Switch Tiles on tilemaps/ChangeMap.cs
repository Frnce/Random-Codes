using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeMap : MonoBehaviour
{
    public static ChangeMap singleton = null;
    public AbstractTiles abstractTiles;
    public Tilemap tileMap;
    EpicSwitch asd;

    public Tile floor;
    public Tile wall;
    public Tile door;
    public Sprite elsee;

    private void Awake()
    {
        if (singleton != null && singleton != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            singleton = this;
        }

        asd = new EpicSwitch();
    }
    // Start is called before the first frame update
    void Start()
    {
        tileMap = FindObjectOfType<Tilemap>();

        if (asd == null)
        {
            Debug.LogError("no tilebase");
        }
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
                    //Sprite dd = tileMap.GetSprite(new Vector3Int(x + bounds.xMin, y + bounds.yMin, 0));
                    Debug.Log("X : " + x + " Y: " + y + " Tile : " + tile.GetInstanceID());
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

public class EpicSwitch : TileBase
{
    AbstractTiles abstractTiles;
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        abstractTiles = ChangeMap.singleton.abstractTiles;
        if (tilemap.GetSprite(position).name == abstractTiles.floor.sprite.name)
        {
            tileData.sprite = ChangeMap.singleton.floor.sprite;
        }
        else if (tilemap.GetSprite(position).name == abstractTiles.wall.sprite.name)
        {
            tileData.sprite = ChangeMap.singleton.wall.sprite;
        }
        else if(tilemap.GetSprite(position).name == abstractTiles.door.sprite.name)
        {
            tileData.sprite = ChangeMap.singleton.door.sprite;
        }
        else
        {
            tileData.sprite = ChangeMap.singleton.elsee;
        }
    }
}
