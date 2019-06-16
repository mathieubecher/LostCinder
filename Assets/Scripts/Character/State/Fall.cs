using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : State
{
    public Fall(Controller character) : base(character)
    {
        character.gameObject.layer = 0;
    }

    public override void Update()
    {
        if (character.rigidbody.velocity.y >= 0) character.activeState = new Iddle(character);
        character.rigidbody.velocity = new Vector3(character.movement * character.speed, character.rigidbody.velocity.y);
    }
    public override string GetName()
    {
        return "Fall";
    }

}
