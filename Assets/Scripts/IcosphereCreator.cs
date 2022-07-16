using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcosphereCreator : MonoBehaviour
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
       // ico = new Icosphere(resolution, origin, size);
        
    }

    void Update () 
    {
        ico = new Icosphere(resolution, origin, size);

        MeshFilter meshF = GetComponent<MeshFilter>();
        
        ico.waveSpeed = waveSpeed;
        ico.waveHeight = waveHeight;
        ico.perlinScale = perlinScale;

        meshF.mesh = ico.ReturnMesh();
        
	}
}
