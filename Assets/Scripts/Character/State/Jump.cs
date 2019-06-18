using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
    public Jump(Controller character) : base(character)
    {
        
        character.gameObject.layer = 9;
        character.rigidbody.velocity = new Vector3(0, 0);
        character.rigidbody.AddForce(character.transform.up * 600);
    }
    public override string GetName()
    {
        return "Jump";
    }


    public override void Update()
    {
        if (character.ground) character.activeState = new Iddle(character);
        character.rigidbody.velocity = new Vector3(MovementJump(character.movement * character.speed), character.rigidbody.velocity.y);
    }
}
