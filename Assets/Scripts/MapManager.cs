using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public int width = 100;
    public int height = 100;
    public float perlinScaleMin = 2f;
    public float perlinScaleMax = 6f;
    public Tile ground;
    public Tile water;
    public float thresholdMin = 0.4f;
    public float thresholdMax = 0.6f;
    public float duration = 1f;

    Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();

        StartCoroutine(NextMap());
    }

    IEnumerator NextMap()
    {
        float perlinScale = Random.Range(perlinScaleMin, perlinScaleMax);
        float threshold = Random.Range(thresholdMin, thresholdMax);

        tilemap.ClearAllTiles();

        PerlinNoiseGrid noise = new PerlinNoiseGrid(width, height, perlinScale);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3Int pos = new Vector3Int(i, j, 0);
                Tile t = (noise[i, j] < threshold) ? ground : water;
                tilemap.SetTile(pos, t);
            }
        }

        yield return new WaitForSeconds(duration);

        StartCoroutine(NextMap());
    }
}
