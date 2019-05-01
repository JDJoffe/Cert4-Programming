using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public Agent agent;
    
    // Update is called once per frame
    void Update()
    {
        // If left mouse is down
        if (Input.GetMouseButtonDown(0))
        {
            // Perform raycast using camera
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(camRay, out hit))
            {
                // Get agent to go to hit point
                agent.GoHere(hit.point);
            }
        }
    }
}
