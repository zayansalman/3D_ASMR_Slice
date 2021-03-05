using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class MeshDeformer : MonoBehaviour
{
    //get the mesh 
    Mesh deformingMesh;
    //get the vertices and save the deformed vertices
    Vector3[] originalVertices, displacedVertices;
    //vertices move when deformed 
    Vector3[] vertexVelocities;
    //return back to shape 
    public float springForce = 20f;
    //damping
    public float damping = 5f; 

    void Start()
    {
        //initialise getting mesh
        deformingMesh = GetComponent<MeshFilter>().mesh;
        //get the vertices of the mesh 
        originalVertices = deformingMesh.vertices;
        //make a copy of the original vertices to the displaced []
        displacedVertices = new Vector3[originalVertices.Length]; 
        for (int i = 0; i < originalVertices.Length; i++)
        {
            displacedVertices[i] = originalVertices[i]; 
        }

        vertexVelocities = new Vector3[originalVertices.Length]; 
    }


    //need to push the vertices towards the center 
    public void AddDeformingForce(Vector3 point, float force)
    {
        //convert to local space so works everywhere
        point = transform.InverseTransformPoint(point); 
        //Debug.DrawLine(Camera.main.transform.position, point); 
        //loop thourhg all currently displaced vertices and apply the deforming force  to each vertex individually
        for (int i = 0; i < displacedVertices.Length; i++)
        {
            AddForceToVertex(i, point, force); 
        }
        
    }


    //force diminishes with distanced, the vertex where the force appplied starts has to get most force and the surrounding vertices less or else if all
    //vertices got equal force the whole object would just move, so need velocity of vertices with distance and direction force per vertex
    void AddForceToVertex(int i, Vector3 point, float force)
    {
        Vector3 pointToVertex = displacedVertices[i] - point;
        //divide original force by distance squared for attenuated force f = f/1 + d^2
        float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
        //convert force to acceleration a = f/m so velocity = a * t so velocity = force * time //ignoring mass for vertice points 
        float velocity = attenuatedForce * Time.deltaTime;
        //direction using normalisation of init vector  
        vertexVelocities[i] += pointToVertex.normalized * velocity; 
    }

    //time to update bc shape is no longer constant and recalculate nromals 
    void Update()
    {
        for (int i = 0; i < displacedVertices.Length; i++)
        {
            UpdateVertex(i); 
        }
        deformingMesh.vertices = displacedVertices;
        deformingMesh.RecalculateNormals(); 
    }

    private void UpdateVertex(int i)
    {
        Vector3 velocity = vertexVelocities[i];
        //return back to original shape 
        Vector3 displacement = displacedVertices[i] - originalVertices[i];
        velocity -= displacement * springForce * Time.deltaTime;
        //dampen and stop deforming
        velocity *= 1f - damping * Time.deltaTime; 
        vertexVelocities[i] = velocity; 
        //

        displacedVertices[i] += velocity * Time.deltaTime; 


    }
}
