using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrapTexture : MonoBehaviour
{
    MeshFilter cubeMesh;
    Mesh mesh;

    void Start()
    {
        //grabs mesh filter of the cube
        cubeMesh = GetComponent<MeshFilter>();
        mesh = cubeMesh.mesh;
        Vector2[] uvMap = mesh.uv;

        //defines the vectors for cube faces to apply net material
        uvMap[0] = new Vector2(0, 0);
        uvMap[1] = new Vector2(0.333f, 0);
        uvMap[2] = new Vector2(0, 0.333f);
        uvMap[3] = new Vector2(0.333f, 0.333f);

        uvMap[4] = new Vector2(0.334f, 0.333f);
        uvMap[5] = new Vector2(0.666f, 0.333f);
        uvMap[8] = new Vector2(0.334f, 0);
        uvMap[9] = new Vector2(0.666f, 0);

        uvMap[6] = new Vector2(1, 0);
        uvMap[7] = new Vector2(0.667f, 0);
        uvMap[10] = new Vector2(1, 0.333f);
        uvMap[11] = new Vector2(0.667f, 0.333f);
        
        uvMap[12] = new Vector2(0, 0.334f);
        uvMap[13] = new Vector2(0, 0.666f);
        uvMap[14] = new Vector2(0.333f, 0.666f);
        uvMap[15] = new Vector2(0.333f, 0.334f);
        
        uvMap[16] = new Vector2(0.334f, 0.334f);
        uvMap[17] = new Vector2(0.334f, 0.666f);
        uvMap[18] = new Vector2(0.666f, 0.666f);
        uvMap[19] = new Vector2(0.666f, 0.334f);
        
        uvMap[20] = new Vector2(0.667f, 0.334f);
        uvMap[21] = new Vector2(0.667f, 0.666f);
        uvMap[22] = new Vector2(1, 0.666f);
        uvMap[23] = new Vector2(1, 0.334f);

        mesh.uv = uvMap;

    }
}