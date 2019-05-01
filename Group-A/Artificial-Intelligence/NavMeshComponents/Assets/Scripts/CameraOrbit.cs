using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Camera attachedCamera;
    public float minYAngle = 30f, maxYAngle = 80f;
    public float xSpeed = 120f, ySpeed = 120f;
    
    void Rotate()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        // Get current euler
        Vector3 euler = transform.eulerAngles;
        // Rotate current euler
        euler.x -= mouseY * ySpeed * Time.deltaTime;
        euler.y += mouseX * xSpeed * Time.deltaTime;
        // Apply to transform
        transform.eulerAngles = euler;
    }
    
    // Update is called once per frame
    void Update()
    {
        // If right mouse button down
        if (Input.GetMouseButton(1))
        {
            // Rotate camera
            Rotate();
        }
    }
}
