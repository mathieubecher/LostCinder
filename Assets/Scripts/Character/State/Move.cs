using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    public Move(Controller character) : base(character)
    {
    }
    public override string GetName()
    {
        return "Move";
    }


    public override void Update()
    {
        character.rigidbody.velocity = new Vector3(character.movement * character.speed, character.rigidbody.velocity.y);
    }
    public override void jump() { character.activeState = new Jump(character); }
    public override void squat() { character.activeState = new Squat(character); }
    public override void carry() { character.activeState = new Carry(character); }
}
