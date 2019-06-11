using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class OnEnter : MonoBehaviour
{
    // Is it going to destroy the incoming object?
    public string hitTag = "";
    public bool destroy = false;
    public UnityEvent onEnter;

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        // If hitTag matches incoming object's tag OR hitTag is set to nothing
        if (hitTag == col.tag || hitTag == "")
        {
            // Does the object need to be destroyed?
            if (destroy)
            {
                // Destroy it!
                Destroy(col.gameObject);
            }
            // Run Unity Event
            onEnter.Invoke();
        }
    }
}
