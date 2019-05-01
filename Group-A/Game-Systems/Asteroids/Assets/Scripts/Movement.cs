using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class Movement : MonoBehaviour
{
    public float speed = 20f; // Units to travel per second
    public float rotationSpeed = 360f; // Amount of rotation per second

    private Rigidbody2D rigid; // Reference to attached Rigidbody2D
    
    private List<int> scoreBoard = new List<int>();
    // Use this for initialization
    void Start()
    {
        // Get the reference to Rigidbody component here
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        // Rotating left or right
        transform.Rotate(Vector3.forward, inputH * rotationSpeed * Time.deltaTime);
        // Move up or down
        rigid.AddForce(inputV * transform.up * speed);
    }
}
