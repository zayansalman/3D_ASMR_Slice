using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformerInput : MonoBehaviour
{
    public float force = 10f;
    public float forceOffset = 0.1f;
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            HandleInput(); 
        }
    }

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //what was hit and the contact point
        RaycastHit hit;
        

        if (Physics.Raycast(inputRay, out hit))
        {
            //when the object is hit with the ray, we get the mesh deformer script/object 
            MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
            if (deformer)
            {
                Vector3 point = hit.point;

                //make the deformation like deform or else force applied would be evenly distributed flat-like
                point += hit.normal * forceOffset;

                deformer.AddDeformingForce(point, force);

            }   
        }
    }

}
