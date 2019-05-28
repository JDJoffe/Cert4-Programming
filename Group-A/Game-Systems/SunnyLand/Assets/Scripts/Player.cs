using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prime31;

public class Player : MonoBehaviour
{
    public float gravity = -10;
    public float moveSpeed = 10f;

    private CharacterController2D controller;
    private Animator anim;
   

    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Run(inputH);
        Climb(inputV);
    }

    void Run(float inputH)
    {
        controller.move(transform.right * inputH * moveSpeed * Time.deltaTime);
        anim.SetBool("IsRunning", inputH != 0);

        // Sneak Peak:
        // rend.flipX = inputH > 0
    }

    void Climb(float inputV)
    {

    }
}
