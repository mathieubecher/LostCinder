using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iddle : State
{
    public Iddle(Controller character) : base(character)
    {
        character.animator.SetBool("Squat", false);
        character.cinder.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        character.rigidbody.mass = 1;
    }

    public override string GetName()
    {
        if (character.movement != 0)
        {
            return "Move";
        }
        else return "Iddle";
    }

    public override void Update()
    {
        character.stateName.text = GetName();
        character.rigidbody.velocity = new Vector3(character.movement * character.speed, character.rigidbody.velocity.y);
    }
    
    public override void jump() { character.activeState = new Jump(character); }
    public override void squat() { character.activeState = new Squat(character); }
    public override void carry() { character.activeState = new Carry(character); }
}
