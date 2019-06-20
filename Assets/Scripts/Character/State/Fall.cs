using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : State
{
    public Fall(Controller character) : base(character)
    {
        character.gameObject.layer = 8;
    }

    public override void Update()
    {
        if (character.ground)
        {
            character.source.PlayOneShot(character.atterissage, 1);
            character.activeState = new Iddle(character);
        }
        character.rigidbody.velocity = new Vector3(MovementJump(character.movement * character.speed), character.rigidbody.velocity.y);
    }
    public override string GetIdentifiant()
    {
        return "Fall";
    }
    public override void fall() { }

}
