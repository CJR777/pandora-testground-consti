using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcosphereCreator : MonoBehaviour
{
    Icosphere ico;
    public int resolution = 3;
    public Vector3 origin = new Vector3 (0,0,0);
    public float size = 1.0f;

    //public Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter meshF = GetComponent<MeshFilter>();
        ico = new Icosphere(resolution, origin, size);
        meshF.mesh = ico.ReturnMesh();
    }
}
