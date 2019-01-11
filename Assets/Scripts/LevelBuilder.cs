using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelBuilder : MonoBehaviour
{
    public int width = 100;
    public int height = 100;
    public float perlinScale = 10f;
    public Tile[] tiles;
    public float[] thresholds;
    public float duration = 1f;

    Tilemap tilemap;
    float lastPerlinScale;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void Update()
    {
        if (!Mathf.Approximately(perlinScale, lastPerlinScale))
        {
            tilemap.ClearAllTiles();

            PerlinNoiseGrid noise = new PerlinNoiseGrid(width, height, perlinScale);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Vector3Int pos = new Vector3Int(i, j, 0);
                    //int index = Mathf.Min(Mathf.FloorToInt(noise[i, j] * tiles.Length), tiles.Length - 1);
                    int index = GetIndex(noise[i, j]);
                    tilemap.SetTile(pos, tiles[index]);
                }
            }

            lastPerlinScale = perlinScale;
        }
    }

    int GetIndex(float value)
    {
        for(int i = 0; i < thresholds.Length; i++)
        {
            if(value < thresholds[i])
            {
                return i;
            }
        }

        return tiles.Length - 1;
    }
}
