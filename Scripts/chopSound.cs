using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class chopSound : MonoBehaviour
{
   public AudioSource source;
     
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "onion")
            //AND TRANSFORM Y ORIENTATION IS DOWN
        {
            source.PlayDelayed(0.1f);
        }

        if (other.tag == "garlic")
        {
            source.PlayDelayed(0.1f);
        }
    }
}
