using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iddle : State
{
    public Iddle(Controller character) : base(character)
    {
        character.animator.SetBool("Squat", false);
    }

    public override string GetName()
    {
        return "Iddle";
    }

    public override void Update()
    {
        character.rigidbody.velocity = new Vector3(0, character.rigidbody.velocity.y);
    }

    public override void Move() { character.activeState = new Move(character); }
    public override void Jump() { character.activeState = new Jump(character); }
    public override void Squat() { character.activeState = new Squat(character); }
}
