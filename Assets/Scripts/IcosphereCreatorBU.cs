using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcosphereCreatorBU : MonoBehaviour
{
    Icosphere ico;
    public int resolution = 3;
    public Vector3 origin = new Vector3 (0,0,0);
    public float size = 1.0f;

    public float perlinScale = 3;
    public float waveSpeed = 0.3f;
    public float waveHeight = 0.3f;

    void Start()
    {
        MeshFilter meshF = GetComponent<MeshFilter>();
        ico = new Icosphere(resolution, origin, size);
        
    }

    void Update () 
    {
        
        MeshFilter meshF = GetComponent<MeshFilter>();
        
        ico.waveSpeed = waveSpeed;
        ico.waveHeight = waveHeight;
        ico.perlinScale = perlinScale;

        meshF.mesh = ico.ReturnMesh();
		//AddPerlinFX();
        
	}

    void AddPerlinFX () 
    {
        MeshFilter meshF = GetComponent<MeshFilter>();
        meshF.mesh = ico.ReturnMesh();
        
        Mesh mesh = meshF.mesh;
        
        mesh.RecalculateNormals();

        Vector3[] verts = mesh.vertices;

        for (int i = 0; i < verts.Length; i++)
        {
            //float pX = (verts[i].x * perlinScale) + (Time.timeSinceLevelLoad * waveSpeed) + offset;
            //float pZ = (verts[i].z * perlinScale) + (Time.timeSinceLevelLoad * waveSpeed) + offset;
            //verts[i] = verts[i] + ((Mathf.PerlinNoise(pX, pZ)) * waveHeight * mesh.normals[i].normalized);
        }

        mesh.vertices = verts;
        

	}
}
