// Trigger bridge: when the knife/trigger volume hits something, sets slicer.isTouched so Slicer runs a cut next frame.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceListener : MonoBehaviour
{
    public Slicer slicer;
    private void OnTriggerEnter(Collider other)
    {
        slicer.isTouched = true;
    }
}


