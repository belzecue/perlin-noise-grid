using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public int width = 100;
    public int height = 100;
    public float perlinScaleMin = 2f;
    public float perlinScaleMax = 5f;
    public Tile[] tiles;
    public float[] thresholds;
    public float duration = 2f;

    Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();

        StartCoroutine(NextMap());
    }

    IEnumerator NextMap()
    {
        float perlinScale = Random.Range(perlinScaleMin, perlinScaleMax);

        tilemap.ClearAllTiles();

        PerlinNoiseGrid noise = new PerlinNoiseGrid(width, height, perlinScale);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                Tile t = tiles[GetIndex(noise[i, j])];
                tilemap.SetTile(pos, t);
            }
        }

        yield return new WaitForSeconds(duration);

        StartCoroutine(NextMap());
    }

    int GetIndex(float value)
    {
        for (int i = 0; i < thresholds.Length; i++)
        {
            if (value < thresholds[i])
            {
                return i;
            }
        }

        return tiles.Length - 1;
    }
}
