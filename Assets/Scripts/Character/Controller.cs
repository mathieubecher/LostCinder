using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{
    public State activeState;
    public float speed = 0.2f;
    public TextMesh stateName;


    public LayerMask whatIsGround;
    public GameObject groundCheck;
    public float groundRadius = 0.2f;

    public Rigidbody2D rigidbody;
    public Animator animator;

    //Shooter
    public GameObject pointer;
    public Material line;
    
    public Transform P1pos;
    public Transform P2pos;
    public Item cinder;
    public Item pushCinder;

    public float movement = 0;
    public bool ground = false;
    private bool pressDown = false;
    public bool click = false;
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
        ground = Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, whatIsGround);
        
        if (Input.GetKey(KeyCode.Q)) movement += -1;
        if (Input.GetKey(KeyCode.D)) movement += 1;
        if (movement != 0)
        {
            GetComponent<SpriteRenderer>().flipX = movement < 0;
        }
        if (Input.GetKey(KeyCode.Space)) activeState.jump();
        if (!ground && rigidbody.velocity.y < 0) activeState.fall();


        if (Input.GetKey(KeyCode.S) && !pressDown)
        {
            pressDown = true;
            if (cinder == null || !cinder.detect) activeState.squat();
            else activeState.carry();
        }

        else if(!Input.GetKey(KeyCode.S))
        {
            pressDown = false;
            activeState.raise();
        }

        if (Input.GetMouseButton(0) && !click)
        {
            activeState.shooting();
        }
        else if(!Input.GetMouseButton(0) && click)
        {
            activeState.shoot();
            click = false;
        }


    }

    
}
