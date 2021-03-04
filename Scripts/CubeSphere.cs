using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://catlikecoding.com/unity/tutorials/cube-sphere/

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CubeSphere : MonoBehaviour

{
    public int gridSize;
    //public int roundness;

    private Mesh mesh;
    private Vector3[] vertices;
    private Vector3[] normals;
    private Color32[] cubeUV; 

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Sphere";
        // WaitForSeconds wait = new WaitForSeconds(0.05f);
        CreateVertices();
        CreateTriangles();
        CreateColliders();
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody r = gameObject.AddComponent<Rigidbody>();
        r.mass = 10;
    }
    private void CreateColliders()
    {
        gameObject.AddComponent<SphereCollider>();

    }
    private void CreateVertices()
    {
        //no duplicate vertices
        int cornerVertices = 8;
        int edgeVertices = (gridSize + gridSize+ gridSize - 3) * 4;
        int faceVertices = (
            (gridSize - 1) * (gridSize - 1) +
            (gridSize - 1) * (gridSize - 1) +
            (gridSize - 1) * (gridSize- 1)) * 2;
        vertices = new Vector3[cornerVertices + edgeVertices + faceVertices];
        normals = new Vector3[vertices.Length];
        int v = 0;

        //render the 4 edges and corners on y axis to make full shape
        for (int y = 0; y <= gridSize; y++)
        {
            //render the bottom of square 4  edges and corners 
            for (int x = 0; x <= gridSize; x++)
            {
                //vertices[v++] = new Vector3(x, y, 0);
                // yield return wait;
                SetVertex(v++, x, y, 0);
            }
            for (int z = 1; z <= gridSize; z++)
            {
                // vertices[v++] = new Vector3(xSize, y, z);
                SetVertex(v++, gridSize, y, z);
                //yield return wait;
            }
            for (int x = gridSize - 1; x >= 0; x--)
            {
                // vertices[v++] = new Vector3(x, y, zSize);
                SetVertex(v++, x, y, gridSize);
                // yield return wait;
            }
            for (int z = gridSize - 1; z > 0; z--)
            {
                //vertices[v++] = new Vector3(0, y, z);
                SetVertex(v++, 0, y, z);
                //yield return wait;
            }

        }
        //make top and bottom cap 
        for (int z = 1; z < gridSize; z++)
        {
            for (int x = 1; x < gridSize; x++)
            {
                // vertices[v++] = new Vector3(x, ySize, z);
                SetVertex(v++, x, gridSize, z);
                //  yield return wait; 
            }
        }
        for (int z = 1; z < gridSize; z++)
        {
            for (int x = 1; x < gridSize; x++)
            {
                //  vertices[v++] = new Vector3(x, 0, z);
                SetVertex(v++, x, 0, z);
                //  yield return wait;
            }
        }


        mesh.vertices = vertices;
        mesh.normals = normals;


        //cube has 8 corners and vertices of the corner are shared 3 times and vertices along the edges are shared twice 
        //12 edges - 4 faces, 4 sets of x,y,z

    }
    public float radius = 1f;
    //make little cube inside big cube and spheres outside little cube ot make rounded cube
    private void SetVertex(int i, int x, int y, int z)
    {
        Vector3 v = new Vector3(x, y, z) * 2f / gridSize - Vector3.one;
        normals[i] = v.normalized;
        vertices[i] = normals[i] * radius;
       // cubeUV[i] = new Color32((byte)x, (byte)y, (byte)z, 0);
    }
    private void CreateTriangles()
    {
        //split rounded cube into 3 faces 
        int[] trianglesZ = new int[(gridSize * gridSize) * 12];
        int[] trianglesX = new int[(gridSize * gridSize) * 12];
        int[] trianglesY = new int[(gridSize * gridSize) * 12];


        //  int quads = (xSize * ySize + xSize * zSize + ySize * zSize) * 2;
        // int[] triangles = new int[quads * 6];
        int ring = (gridSize + gridSize) * 2;
        //  int t = 0, v = 0;
        int tZ = 0, tX = 0, tY = 0, v = 0;


        for (int y = 0; y < gridSize; y++, v++)
        {
            for (int q = 0; q < gridSize; q++, v++)
            {
                tZ = SetQuad(trianglesZ, tZ, v, v + 1, v + ring, v + ring + 1);
            }
            for (int q = 0; q < gridSize; q++, v++)
            {
                tX = SetQuad(trianglesX, tX, v, v + 1, v + ring, v + ring + 1);
            }
            for (int q = 0; q < gridSize; q++, v++)
            {
                tZ = SetQuad(trianglesZ, tZ, v, v + 1, v + ring, v + ring + 1);
            }
            for (int q = 0; q < gridSize - 1; q++, v++)
            {
                tX = SetQuad(trianglesX, tX, v, v + 1, v + ring, v + ring + 1);
            }
            tX = SetQuad(trianglesX, tX, v, v - ring + 1, v + ring, v + 1);
        }

        //   t = CreateTopFace(triangles, t, ring);
        //  t = CreateBottomFace(triangles, t, ring); 
        tY = CreateTopFace(trianglesY, tY, ring);
        tY = CreateBottomFace(trianglesY, tY, ring);

        //mesh.triangles = triangles;
        mesh.subMeshCount = 3;
        mesh.SetTriangles(trianglesZ, 0);
        mesh.SetTriangles(trianglesX, 1);
        mesh.SetTriangles(trianglesY, 2);
    }

    private int CreateBottomFace(int[] triangles, int t, int ring)
    {

        //like create top face but somewhat different
        int v = 1;
        int vMid = vertices.Length - (gridSize - 1) * (gridSize - 1);
        t = SetQuad(triangles, t, ring - 1, vMid, 0, 1);
        for (int x = 1; x < gridSize - 1; x++, v++, vMid++)
        {
            t = SetQuad(triangles, t, vMid, vMid + 1, v, v + 1);
        }
        t = SetQuad(triangles, t, vMid, v + 2, v, v + 1);

        int vMin = ring - 2;
        vMid -= gridSize - 2;
        int vMax = v + 2;

        for (int z = 1; z < gridSize - 1; z++, vMin--, vMid++, vMax++)
        {
            t = SetQuad(triangles, t, vMin, vMid + gridSize - 1, vMin + 1, vMid);
            for (int x = 1; x < gridSize - 1; x++, vMid++)
            {
                t = SetQuad(
                    triangles, t,
                    vMid + gridSize - 1, vMid + gridSize, vMid, vMid + 1);
            }
            t = SetQuad(triangles, t, vMid + gridSize - 1, vMax + 1, vMid, vMax);
        }

        int vTop = vMin - 1;
        t = SetQuad(triangles, t, vTop + 1, vTop, vTop + 2, vMid);
        for (int x = 1; x < gridSize - 1; x++, vTop--, vMid++)
        {
            t = SetQuad(triangles, t, vTop, vTop - 1, vMid, vMid + 1);
        }
        t = SetQuad(triangles, t, vTop, vTop - 1, vMid, vTop - 2);
        return t;
    }
    private int CreateTopFace(int[] triangles, int t, int ring)
    {

        //first row
        int v = ring * gridSize;
        for (int x = 0; x < gridSize - 1; x++, v++)
        {
            t = SetQuad(triangles, t, v, v + 1, v + ring - 1, v + ring);
        }
        t = SetQuad(triangles, t, v, v + 1, v + ring - 1, v + 2);


        //middle row
        int vMin = ring * (gridSize + 1) - 1;
        int vMid = vMin + 1;
        int vMax = v + 2;
        for (int z = 1; z < gridSize - 1; z++, vMin--, vMid++, vMax++)
        {
            t = SetQuad(triangles, t, vMin, vMid, vMin - 1, vMid + gridSize - 1);
            for (int x = 1; x < gridSize - 1; x++, vMid++)
            {
                t = SetQuad(
                    triangles, t,
                    vMid, vMid + 1, vMid + gridSize - 1, vMid + gridSize);
            }
            t = SetQuad(triangles, t, vMid, vMax, vMid + gridSize - 1, vMax + 1);
        }


        //last row 
        int vTop = vMin - 2;
        t = SetQuad(triangles, t, vMin, vMid, vTop + 1, vTop);
        for (int x = 1; x < gridSize - 1; x++, vTop--, vMid++)
        {
            t = SetQuad(triangles, t, vMid, vMid + 1, vTop, vTop - 1);
        }
        t = SetQuad(triangles, t, vMid, vTop - 2, vTop, vTop - 1);


        return t;
    }
    //create the square mesh sections - aka quads, A Qquad has 2 triangles, 
    private static int
    SetQuad(int[] triangles, int i, int v00, int v10, int v01, int v11)
    {
        triangles[i] = v00;
        triangles[i + 1] = triangles[i + 4] = v01;
        triangles[i + 2] = triangles[i + 3] = v10;
        triangles[i + 5] = v11;
        return i + 6;
    }


    //private void OnDrawGizmos()
    //{
    //    if (vertices == null)
    //    {
    //        return;
    //    }
    //    Gizmos.color = Color.black;
    //    for (int i = 0; i < vertices.Length; i++)
    //    {
    //        Gizmos.color = Color.black;
    //        Gizmos.DrawSphere(vertices[i], 0.1f);
    //        Gizmos.color = Color.yellow;
    //        Gizmos.DrawRay(vertices[i], normals[i]);
    //    }
    //}
}
