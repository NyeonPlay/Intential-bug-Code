using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechans : MonoBehaviour
{
    [Header("Movement")]
    public float movespeed;

    [Header("Ground Check")]
    public float Ground_Drag;

    public float Player_Hieght;

    public LayerMask WhatisGround;
    public bool Grounded;



    public Transform orientation;

    float H_inputs;
    float v_inputs;
    Vector3 move_direction;
    Rigidbody rb;

    public float jump_force;
    public float Gravity;
    bool jump;
    public float Airmutlipier;
    public KeyCode J_Key = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    // Update is called once per frame
    void Update()
    {
        MyInputs();
        Grounded = Physics.Raycast(transform.position, Vector3.down, Player_Hieght * 0.5f + .2f, WhatisGround);
        if (Grounded)
        {
            rb.drag = Ground_Drag;
        }
        else rb.drag = 0;
    }
    private void MyInputs()
    {
        H_inputs = Input.GetAxisRaw("Horizontal");
        v_inputs = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = false;

            Jump();

            Invoke(nameof(restjump), Gravity);
            Debug.Log("pressed");


        }

    }


    private void MovePlayer()
    {
        move_direction = orientation.forward * v_inputs + orientation.right * H_inputs;


        if (Grounded)
        {
            rb.AddForce(move_direction.normalized * movespeed * 10f, ForceMode.Force);
        }
        else if (!Grounded)
            rb.AddForce(move_direction.normalized * movespeed * Airmutlipier * 10f, ForceMode.Force);


    }

    private void Jump()
    {
       // rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jump_force, ForceMode.Impulse);

    }


    private void restjump()
    {
        jump = true;

    }
}
