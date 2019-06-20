using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : State
{
    private bool beginjump = false;
    public Jump(Controller character) : base(character)
    {
        character.source.PlayOneShot(character.saut, 0.5f);
        character.gameObject.layer = 9;
        character.rigidbody.AddForce(character.transform.up * 450);
    }
    public override string GetIdentifiant()
    {
        return "Jump";
    }


    public override void Update()
    {
        if (!beginjump && character.rigidbody.velocity.y > 0) beginjump = true;
        if (beginjump && character.ground && character.rigidbody.velocity.y <= 0) character.activeState = new Iddle(character);
        character.rigidbody.velocity = new Vector3(MovementJump(character.movement * character.speed), character.rigidbody.velocity.y);
    }
}
