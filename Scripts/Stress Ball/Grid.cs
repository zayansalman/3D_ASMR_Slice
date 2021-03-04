using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
    public int xSize, ySize;
    public Vector3[] vertices;
    private Mesh mesh; 
    private void Awake()
    {
        Generate(); 
    }

    private void Generate()
        //we need 1 more vertex than we have tiles in the dimension. 
        //need to hold an array of 3d vectors to store the points
        //need a vertex at corners of every quad in the grid
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        
        //create mesh 
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid"; 

        //intiallize array size

        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
       // Vector2[] uv = new Vector2[vertices.Length];
        //iterate through all the positions 
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                //add vertices , position them 
                vertices[i] = new Vector3(x, y);
              //  uv[i] = new Vector2((float) x / xSize, (float) y / ySize);
               
            }
        }
        //assign mesh
        mesh.vertices = vertices;
      //  mesh.uv = uv; 

        //triangles are an array of vertex indices - three consecutive points describe one triangle
        // int[] triangles = new int[6];
        //triangles[0] = 0;
        //jump to first vertex of next row
        //shared vertexes to form triangles
        // triangles[3] = triangles[2] = 1;
        // triangles[4] = triangles[1] = xSize + 1;
        // triangles[5] = xSize + 2; 


        //fill all the grids with meshes
        int[] triangles = new int[xSize * ySize * 6];  
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
        { for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2; 
            }

        }
        //put the triangles in the mesh
        mesh.triangles = triangles;
        //add normals the mesh
        mesh.RecalculateNormals();


    }

    private void OnDrawGizmos()
        //visualise vertices with a small black sphere in scene for every vertex 
    {
        if (vertices == null)
        {
            return; 
        }
        Gizmos.color = Color.black; 
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f); 
        }
    }
}


