using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squat : State
{
    public Squat(Controller character) : base(character)
    {
        character.animator.SetBool("Squat",true);
    }
    public override void Update()
    {
        character.rigidbody.velocity = new Vector3(0, character.rigidbody.velocity.y);
    }

    public override string GetName()
    {
        return "Squat";
    }
    public override void Raise() { character.activeState = new Iddle(character); }
}
