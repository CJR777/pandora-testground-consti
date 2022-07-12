using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.VFX;
using UnityEngine.VFX.SDF;

public class SDFBaker : MonoBehaviour
{
    static int maxResolution = 64, signPassCount = 1;
    static Vector3 center, sizeBox;
    static float threshold = 0.5f;
    public Mesh mesh;
    
    public static RenderTexture ConvertToSDF (Mesh mesh)
    {
        MeshToSDFBaker meshBaker = new MeshToSDFBaker
        (
            sizeBox,
            center,
            maxResolution,
            mesh,
            signPassCount,
            threshold
        );
        
        meshBaker.BakeSDF();
        RenderTexture sdf = new RenderTexture(meshBaker.SdfTexture);

        if (meshBaker != null)
        {
            meshBaker.Dispose();
        }
        
        return sdf;
    }
}
