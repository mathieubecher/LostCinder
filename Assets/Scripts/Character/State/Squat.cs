using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squat : State
{
    public Squat(Controller character) : base(character)
    {
        character.GetComponent<BoxCollider2D>().offset = new Vector2(0,-0.26f);
        character.GetComponent<BoxCollider2D>().size = new Vector2(0.7f, 0.5f);
    }
    public override void Update()
    {
        character.rigidbody.velocity = new Vector3(0, character.rigidbody.velocity.y);
    }

    public override string GetIdentifiant()
    {
        return "Squat";
    }
    public override void raise() { character.activeState = new Iddle(character); }
}
