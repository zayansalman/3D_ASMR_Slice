using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl2 : MonoBehaviour
{
    private Touch touch;
    public float speedModifierSide;
    public float speedModifierDown;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        //move knife
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0); 

            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifierSide * 1f,
                  transform.position.y + touch.deltaPosition.y * speedModifierDown * 1f,
                 transform.position.z); 
                
                
            }
           
        }


        //rotate the knife with 2nd finger on touch
        if (Input.touchCount > 1)
        {
            touch = Input.GetTouch(1);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.rotation = new Quaternion(transform.rotation.x,
                     transform.rotation.y + touch.deltaPosition.x * speedModifierSide,
                     transform.rotation.z,
                     1);

            }

        }
    }
}
