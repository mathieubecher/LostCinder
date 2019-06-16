using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{
    public State activeState;
    public float speed = 0.2f;
    public float gravity = 20;
    public TextMesh stateName;

    public LayerMask whatIsGround;
    public GameObject groundCheck;
    public float groundRadius = 0.2f;

    public Rigidbody2D rigidbody;
    public Animator animator;

    public float movement = 0;
    public bool ground = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent< Rigidbody2D>();
        animator = GetComponent<Animator>();
        activeState = new Iddle(this);
    }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
        activeState.Update();

    }
    private void DetectInput()
    {
        movement = 0;
        //ground = Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, whatIsGround);
        //Debug.Log(groundCheck.transform.position + " " + ground);
        
        if (Input.GetKey(KeyCode.Q)) movement += -1;
        if (Input.GetKey(KeyCode.D)) movement += 1;
        if (movement != 0)
        {
            GetComponent<SpriteRenderer>().flipX = movement < 0;
            activeState.Move();
        }
        else activeState.Iddle();

        if (Input.GetKey(KeyCode.Space)) activeState.Jump();
        if (rigidbody.velocity.y < 0) activeState.Fall();

        if (Input.GetKey(KeyCode.S)) activeState.Squat();
        else activeState.Raise();

    }
}
