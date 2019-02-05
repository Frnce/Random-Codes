using UnityEngine;
using UnityEngine.Tilemaps;

// Tile that repeats two sprites in checkerboard pattern
[CreateAssetMenu]
public class TileSwitch : TileBase
{
    public Tile Blue;
    public Tile Green;

    public Tile NewTile1;
    public Tile NewTile2;
    public Sprite elsee;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        if(tilemap.GetSprite(position).name == Blue.sprite.name)
        {
            tileData.sprite = NewTile1.sprite;
        }
        else if(tilemap.GetSprite(position).name == Green.sprite.name)
        {
            tileData.sprite = NewTile2.sprite;
        }
        else
        {
            tileData.sprite = elsee;
        }
    }
}