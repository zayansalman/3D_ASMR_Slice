using UnityEngine;
using EzySlice;
public class Slicer : MonoBehaviour
{
    public Material materialAfterSlice;
    public Material onionInside;
    public Material garlicInside; 

    public LayerMask sliceMask;

    public bool isTouched;

    string onionTag = "onion";
    string garlicTag = "garlic";
    string sandTag = "sand";
    string objectTag; 

    public Transform slicer;

    private void Update()
    {
        float slicerPosition = slicer.transform.position.y;

        if (isTouched == true)
        {
            isTouched = false;
            
            //https://docs.unity3d.com/ScriptReference/Physics.OverlapBox.html 
            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
            
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                objectTag = objectToBeSliced.tag; 
                switch (objectTag)
                {
                    case "onion":
                        sliceObject(objectToBeSliced, onionInside, onionTag);
                        break;

                    case "garlic":
                        sliceObject(objectToBeSliced, garlicInside, garlicTag);
                        break;

                    case "sand":
                        sliceObject(objectToBeSliced, materialAfterSlice, sandTag, slicerPosition);
                        break;
                }
            } 
        }
    }

    // Method to slice object 
    public void sliceObject(Collider objectToBeSliced, Material objectInside, string tag, float sPos = 0.0f)
    {
        SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, objectInside);

        GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, objectInside);
        GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, objectInside);

        //set the position as the original
        upperHullGameobject.transform.position = objectToBeSliced.transform.position;
        lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

        //instantiate its existance 
        MakeItPhysical(upperHullGameobject);
        MakeItPhysical(lowerHullGameobject);

        //kill the original object so now you have the two seprate sliced objects
        Destroy(objectToBeSliced.gameObject);

        //if tag is apple, then set material after slice to apple inside 
        //if tag is sand set sand inside for material after slice 
        upperHullGameobject.layer = LayerMask.NameToLayer("Sliceable");
        lowerHullGameobject.layer = LayerMask.NameToLayer("Sliceable");
        upperHullGameobject.tag = tag;
        lowerHullGameobject.tag = tag;

        if (objectToBeSliced.tag == "sand")
        {
            //initialize shader
            Renderer makeRoll; ;
            Shader sandRoll = Shader.Find("Custom/BzKovSoft/RollProgressed");
            makeRoll = lowerHullGameobject.GetComponent<MeshRenderer>();
            makeRoll.material.shader = sandRoll;

            //keep seting PointY to new point Y value, while, for, if
            //while the existence of sandlowerhull is true, do decreasing pointY
            while (pointY(sPos) > -0.5f)
            {
                makeRoll.material.SetFloat("_PointY", pointY(sPos));
                makeRoll.material.SetFloat("_PointX", 0.4f);
                break;
            }
            //SandlowerHullGameobject.GetComponent<Renderer>().sharedMaterial.SetFloat("_PointY", PointY);
            //SandlowerHullGameobject.GetComponent<Renderer>().sharedMaterial.SetFloat("_PointX", 0.4f);
        }
    }

    private float pointY(float sPos) 
    {
        float pointY = 0.0f;
        if (sPos < sPos)
        {
            pointY = pointY - 0.3f;
        }
       else if (sPos > sPos)
        {
            pointY = 0.74f;
        }
        return pointY;

    }
    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
    }


    //takes GameObject given and material and applies Slice method to the object. 
    
    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
        /*
        The slice method on the object takes the position as a vector3 and 
        Transform.up manipulates the game object on y axis 
        Material for new objects inside slice
        */
    }


}
