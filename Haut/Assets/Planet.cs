using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

    public float perlinScale;
    public float waveSpeed;
    public float waveHeight;
    public float offset;

    public Mesh meshrender;
    public RenderTexture rendT;

    Vector3[] baseVertices;

    
    private void OnEnable()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;

        baseVertices = mesh.vertices;
      
    }

    private void Start() {
 
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;

        baseVertices = mesh.vertices;
        meshrender = mesh;
        
    }

    void Update()
    {

        CalcNoise3();
        // BakeSDF();
        
    }

    void CalcNoise3()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;


        mesh.vertices = baseVertices;
        mesh.RecalculateNormals();

        Vector3[] verts = mesh.vertices;

        for (int i = 0; i < verts.Length; i++)
        {
            float pX = (verts[i].x * perlinScale) + (Time.timeSinceLevelLoad * waveSpeed) + offset;
            float pZ = (verts[i].z * perlinScale) + (Time.timeSinceLevelLoad * waveSpeed) + offset;
            verts[i] = verts[i] + ((Mathf.PerlinNoise(pX, pZ)) * waveHeight * mesh.normals[i].normalized);
        }

        mesh.vertices = verts;
        //GetComponent<MeshFilter>().sharedMesh = mesh;
        
    }

    // void BakeSDF()
    //{
    //    rendT = SDFBaker.ConvertToSDF(meshrender);
    //}
    
}