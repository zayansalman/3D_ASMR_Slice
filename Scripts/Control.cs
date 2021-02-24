using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Transform shape;
    public Transform cutter; 

        public void MoveShape(float x)
    {
        var pos = shape.position;
        pos.x = x;
        shape.position = pos; 
    }

        public void MoveCutter(float y)
    {
        var pos = cutter.position;
        pos.y = y;
        cutter.position = pos; 
    }
    

}
