using UnityEngine;

public class HautGENCUB : MonoBehaviour
{
    public int width = 256; 
    public int height = 256; 

    public float depth = 20; 

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    private void Start()
    {
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
    }

    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateHaut(terrain.terrainData);
        offsetX += Time.deltaTime * .5f;
        offsetY += Time.deltaTime * .2f;

        while (depth < 2.9) {
            depth ++;
        }
        
        //if (depth <= 2.9) {
         //   depth += Time.deltaTime * 2; 
       // }
        
        //else {
          //  depth += Time.deltaTime * 2;
        //}

    }

    TerrainData GenerateHaut (TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    float CalculateHeight (int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}