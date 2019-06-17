﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class State
{
    public static float jumpSpeed = 1;
    public float MovementJump(float movement)
    {
        return movement * jumpSpeed;
    }
    public float MovementCinder(float movement)
    {
        return movement / (1 + character.cinder.weight);
    }
    public void carryCinder()
    {
        Vector3 direction = character.right.transform.localPosition;
        if (character.GetComponent<SpriteRenderer>().flipX) direction.x *= -1;
        character.cinder.transform.position = direction+character.transform.position;
    }


    protected Controller character;

    public State(Controller character)
    {
        this.character = character;
        character.stateName.text = GetName();
    }

    public virtual string GetName()
    {
        return "State";
    }

    public virtual void Update() { }
    public virtual void move() { }
    public virtual void iddle() { }
    public virtual void jump() { }
    public virtual void squat() { }
    public virtual void raise() { }
    public virtual void carry() { }
    public virtual void shooting() { }
    public virtual void shoot() { }
    public virtual void fall() { character.activeState = new Fall(character); }

}
