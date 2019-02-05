using UnityEngine;
using UnityEngine.Tilemaps;

// Tile that repeats two sprites in checkerboard pattern
[CreateAssetMenu]
public class TileSwitch : TileBase
{
    public Tile spriteA;
    public Tile spriteB;
    public Sprite elsee;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        if(tilemap.GetSprite(position).name == spriteA.sprite.name)
        {
            tileData.sprite = spriteB.sprite;
        }
        else if(tilemap.GetSprite(position).name == spriteB.sprite.name)
        {
            tileData.sprite = spriteA.sprite;
        }
        else
        {
            tileData.sprite = elsee;
        }
    }
}