using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hideCursor = false;
    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;
    public float maxVelocity = 20f;

    private Rigidbody rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Should the cursor be hidden?
        if (hideCursor)
        {
            // Hide it!
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }    
    }
    
    // Update is called once per frame
    void Update()
    {
        // Get input from user
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        // Get character (cube) to move
        Move(inputH, inputV);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Did we hit a thing with an Item component?
        Item item = other.GetComponent<Item>();
        if (item)
        {
            // Collect it!
            item.Collect();
        }
    }

    public void Move(float inputH, float inputV)
    {
        // 1. Copy rigid.velocity to 'velocity' vector
        Vector3 velocity = rigid.velocity;
        // 2. Get input from user into 'inputDirection' vector
        Vector3 inputDirection = new Vector3(inputH, 0, inputV);
        // 3. Convert inputDirection from localspace to worldspace and store in 'direction' variable
        Vector3 direction = transform.TransformDirection(inputDirection);
        // 4. Set 'velocity' to Vector3(direction (x), velocity (y), direction (z)) and multiply by moveSpeed
        velocity = new Vector3(direction.x, velocity.y, direction.z) * moveSpeed;
        // 5. Apply new velocity to 'rigid.velocity' 
        rigid.velocity = velocity;

        // Extra
        // Convert from World Space to Local Space via one axis
        //Transform camTransform = Camera.main.transform;
        //Vector3 camEuler = camTransform.eulerAngles;
        //// Localise the direction of input to the Camera Y angle (degrees)
        //velocity = Quaternion.Euler(0f, camEuler.y, 0f) * velocity; 
    }
}
