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

    void FixedUpdate()
    {
        float inputR = Input.GetAxis("Mouse X");
        Rotate(inputR);
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Move(inputH, inputV);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Did we hit an item?
        Item item = other.GetComponent<Item>();
        if (item)
        {
            // Collect it!
            item.Collect();
        }
    }

    public void Move(float inputH, float inputV)
    {
        Vector3 velocity = rigid.velocity;
        Vector3 direction = transform.TransformDirection(new Vector3(inputH, 0, inputV)) * moveSpeed;
        velocity = new Vector3(direction.x, velocity.y, direction.z);
        rigid.velocity = velocity;

        // Convert from World Space to Local Space via one axis
        //Transform camTransform = Camera.main.transform;
        //Vector3 camEuler = camTransform.eulerAngles;
        //// Localise the direction of input to the Camera Y angle (degrees)
        //velocity = Quaternion.Euler(0f, camEuler.y, 0f) * velocity; 
    }
    
    public void Rotate(float inputR)
    {
        // Rotating using Rigidbody (using Physics)
        float angle = inputR * rotationSpeed * Time.deltaTime;
        Quaternion rotation = rigid.rotation * Quaternion.AngleAxis(angle, Vector3.up);
        rigid.MoveRotation(rotation);

        // Rotating object forcibly (using Translate) #nofilter
        //transform.Rotate(Vector3.up, inputR * rotationSpeed * Time.deltaTime);
    }
}
