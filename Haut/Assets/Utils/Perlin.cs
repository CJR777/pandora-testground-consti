using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Perlin : MonoBehaviour {
 
     public float height=0.2f; // max height (model space)
     public float mult=200f; // perlin granularity
 
     public float vel=60f; // planet rotation speed degrees/second
 
     Vector3 offset;
 
     void Start () {
         // select a random offset
         offset = mult * Random.insideUnitSphere;
         CreateHills ();
     }
     
     float PerlinHeight(Vector3 v){
         Vector3 pos = v * mult + offset; // apply offset and mult
         pos.y += pos.z; pos.x -= pos.z; // combine x,y with z
         return Mathf.PerlinNoise (pos.x, pos.y); // return perlin noise
     }
 
     void CreateHills(){
         Mesh mesh = GetComponent<MeshFilter> ().mesh;
         Vector3[] verts = mesh.vertices;
         Vector2[] uvs = mesh.uv;
         for (int i = 0; i < verts.Length; i++) {
             Vector3 v = verts [i];
             float h = PerlinHeight (v); // get perlin value (0..1)
             verts [i] = v * (1 + height * h); // move vertex away from center by h*height
             uvs [i] = new Vector2 (h, 0); // set uv to allow different colors according to height
         }
         mesh.vertices = verts; // set the modified vertices...
         mesh.uv = uvs; // and uvs
         // update normals without Unity limitations
         NormalSolver.RecalculateNormals (mesh, 60f);
     }
 
     void Update () {
         // demo: just rotate planet
         transform.Rotate (Vector3.up, Time.deltaTime * vel);
     }
 
 }