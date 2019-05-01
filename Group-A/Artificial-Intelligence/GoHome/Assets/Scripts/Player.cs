using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 20f;

    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        // Get reference to rigidbody
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input axis
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        // Create input vector
        Vector3 input = new Vector3(inputH, 0, inputV);
        // Apply velocity
        rigid.velocity = input * movementSpeed;
    }
}
