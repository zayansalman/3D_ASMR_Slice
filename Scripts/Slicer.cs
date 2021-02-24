using UnityEngine;
using EzySlice;
public class Slicer : MonoBehaviour
{
    public Material materialAfterSlice;
    public Material onion;
    public Material garlic; 
    public LayerMask sliceMask;
    public bool isTouched;
    public Transform slicer;
    float pointY = 0.0f;

    private void Update()
    {
        float slicerPosition = slicer.position.y;

        

        if (isTouched == true)
        {
            isTouched = false;
           
            //use physics overlap box to know if the slicing plane has touched another collider - plane position, minimal size for invisible box, etc etc)
            //https://docs.unity3d.com/ScriptReference/Physics.OverlapBox.html 
            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
            //so for each collider deteced in the array slice it 
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                

                if (objectToBeSliced.tag == "onion")
                {
                    //set object to be sliced as current game object and material as onion which is assigned in editor
                   

                    SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, onion);



                    GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, onion);
                    GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, onion);



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
                    upperHullGameobject.tag = "onion";
                    lowerHullGameobject.tag = "onion";

                }

                else if (objectToBeSliced.tag == "garlic")
                {
                
                    SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, garlic);



                    GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, garlic);
                    GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, garlic);




                    upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                    lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                    MakeItPhysical(upperHullGameobject);
                    MakeItPhysical(lowerHullGameobject);

                    Destroy(objectToBeSliced.gameObject);

                    //if tag is apple, then set material after slice to apple inside 
                    //if tag is sand set sand inside for material after slice 
                    upperHullGameobject.layer = LayerMask.NameToLayer("Sliceable");
                    lowerHullGameobject.layer = LayerMask.NameToLayer("Sliceable");
                    upperHullGameobject.tag = "garlic";
                    lowerHullGameobject.tag = "garlic";
                }

                else if (objectToBeSliced.tag == "sand")
                {

                //WHILE THE SLICER POSITION IS IN THE BOX 
                 //   pointY = Mathf.InverseLerp(startValue, endValue, );
                 //   timeElapsed += Time.deltaTime;

                    SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);

                    GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                    GameObject SandlowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

                    upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                    SandlowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                    MakeItPhysical(upperHullGameobject);
                    MakeItPhysical(SandlowerHullGameobject);

                    Destroy(objectToBeSliced.gameObject);

                    //if tag is apple, then set material after slice to apple inside 
                    //if tag is sand set sand inside for material after slice 
                    upperHullGameobject.layer = LayerMask.NameToLayer("Sliceable");
                    SandlowerHullGameobject.layer = LayerMask.NameToLayer("Sliceable");
                    upperHullGameobject.tag = "sand";
                    SandlowerHullGameobject.tag = "sand";

                    //initialize shader
                    Renderer makeRoll; ;
                    Shader sandRoll = Shader.Find("Custom/BzKovSoft/RollProgressed");
                    makeRoll = SandlowerHullGameobject.GetComponent<MeshRenderer>();
                    makeRoll.material.shader = sandRoll;

                    //keep seting PointY to new point Y value, while, for, if
                    //while the existence of sandlowerhull is true, do decreasing pointY
                    if ( pointY > -0.5f)
                    {
                         
                        makeRoll.material.SetFloat("_PointY", Mathf.InverseLerp(-0.5f, 0.74f,pointY));
                         pointY -= 0.5f;
                        Debug.Log(pointY); 
                        makeRoll.material.SetFloat("_PointX", 0.4f);
                        //break; 
                    }
                    
                    //SandlowerHullGameobject.GetComponent<Renderer>().sharedMaterial.SetFloat("_PointY", PointY);
                    // SandlowerHullGameobject.GetComponent<Renderer>().sharedMaterial.SetFloat("_PointX", 0.4f);
                }

            }

            
        }

        
    }

    public float PointY()
    {
        if (isTouched == false)
        {
           

            // if (pointY < -0.5f)
            // {
            //   reducer = 0f;
            //   pointY = initY;

            // } 
        }
        return 0f; 
    }

    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
    }


    
    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }


}
