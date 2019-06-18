using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Hold : State
{
    Vector3 last;
    public Hold(Controller character) : base(character)
    {
        last = character.transform.position;
        character.click = true;
    }
    public override void Update()
    {
        if(character.pushCinder != null) {
            character.rigidbody.velocity = new Vector3(MovementPush(character.movement * character.speed), character.rigidbody.velocity.y);
            character.pushCinder.GetComponent<Rigidbody2D>().velocity = new Vector3(MovementPush(character.movement * character.speed), character.pushCinder.GetComponent<Rigidbody2D>().velocity.y);
            last = character.transform.position;
        }
        else
        {
            character.activeState = new Iddle(character);
        }
    }
    public override string GetName()
    {
        return "Hold";
    }

    public override void jump() { character.activeState = new Jump(character); }
    public override void squat() { character.activeState = new Squat(character); }
    public override void carry() { character.activeState = new Carry(character); }
    public override void shoot() { character.click = false; character.pushCinder = null; character.activeState = new Iddle(character); }
}
