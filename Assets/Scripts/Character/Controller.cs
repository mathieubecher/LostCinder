﻿using System.Collections;
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
    public float distancePush=0;
    public float distanceLeave=0.2f;

    public float movement = 0;
    public bool ground = false;
    private bool pressDown = false;
    public bool click = false;
    private bool space = false;
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
        
        if(pushCinder!=null)
        {
            distancePush = GetComponent<Collider2D>().Distance(pushCinder.GetComponent<Collider2D>()).distance;
            if(distancePush > distanceLeave)
            pushCinder = null;
        }
        activeState.Update();
        activeState.SetAnim();

        if (cinder != null && cinder.character == null)
        {
            //Debug.Log(cinder + " " + cinder.character);
            cinder.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            cinder.GetComponent<Collider2D>().isTrigger = false;
            cinder = null;
            if (activeState.GetIdentifiant() == ("Carry")) activeState = new Iddle(this);
        }
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
        if (Input.GetKey(KeyCode.Space) && !space)
        {
            space = true;
            activeState.jump();
        }
        else if(!Input.GetKey(KeyCode.Space)) space = false;
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
