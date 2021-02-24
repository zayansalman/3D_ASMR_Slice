using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public float intensity = 1f;
    public float mass = 1f;
    public float stifness = 1f;
    public float damping = 0.75f; 
    private Mesh originalMesh, meshClone;
    private MeshRenderer renderer;
    public JellyVertex[] jellyVertex;
    private Vector3[] vertexArray; 


    // Start is called before the first frame update
    void Start()
    {
        originalMesh = GetComponent<MeshFilter>().sharedMesh;
        meshClone = Instantiate(originalMesh);
        GetComponent<MeshFilter>().sharedMesh = meshClone;
        renderer = GetComponent<MeshRenderer>();

        jellyVertex = new JellyVertex[meshClone.vertices.Length];
        for (int i = 0; i < meshClone.vertices.Length; i++)
            jellyVertex[i] = new JellyVertex(i, transform.TransformPoint(meshClone.vertices[i]));
            

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vertexArray = originalMesh.vertices; 
        for (int i = 0; i < jellyVertex.Length; i++)
        {
            Vector3 target = transform.TransformPoint(vertexArray[jellyVertex[i].ID]);
            float intensity1 = (1 - (renderer.bounds.max.y - target.y) / renderer.bounds.size.y) * intensity;
            jellyVertex[i].Shake(target, mass, stifness, damping);
            target = transform.InverseTransformPoint(jellyVertex[i].position);
            vertexArray[jellyVertex[i].ID] = Vector3.Lerp(vertexArray[jellyVertex[i].ID], target, intensity); 

        }
        meshClone.vertices = vertexArray; 
    }

    public class JellyVertex
    {
        public int ID;
        public Vector3 position, velocity, force; 

        public JellyVertex (int id, Vector3 pos)
        {
            ID = id;
            position = pos; 
        }

        public void Shake(Vector3 target, float m, float s, float d)
        {
            force = (target - position) * s;
            velocity = (velocity + force / m) * d;
            position += velocity;
            if ((velocity + force + force / m).magnitude < 0.001f)
                position = target; 
        }
    }

}


