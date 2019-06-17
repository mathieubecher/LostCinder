﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : State
{
    public Carry(Controller character) : base(character)
    {
        character.cinder.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        character.rigidbody.mass = 1 + character.cinder.weight;
    }
    public override void Update()
    {
        carryCinder();
        character.rigidbody.velocity = new Vector3(MovementCinder(character.movement * character.speed), character.rigidbody.velocity.y);
    }
    public override string GetName()
    {
        return "Carry";
    }
    public override void jump() { if(character.cinder.weight<character.cinder.P2)character.activeState = new CarryJump(character); }
    public override void carry() { character.activeState = new Iddle(character); }
    public override void fall() { character.activeState = new CarryFall(character); }
    public override void shooting() { character.activeState = new Shoot(character); }
}
