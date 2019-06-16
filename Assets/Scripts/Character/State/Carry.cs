﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : State
{
    public Carry(Controller character) : base(character)
    {
        character.cinder.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public override void Update()
    {
        if(character.GetComponent<SpriteRenderer>().flipX) character.cinder.transform.position = character.left.position;
        else character.cinder.transform.position = character.right.position;
        character.rigidbody.velocity = new Vector3(character.movement * character.speed, character.rigidbody.velocity.y);
    }
    public override string GetName()
    {
        return "Carry";
    }
    public override void jump() { character.activeState = new CarryJump(character); }
    public override void carry() { character.activeState = new Iddle(character); }
    public override void fall() { character.activeState = new CarryFall(character); }
}