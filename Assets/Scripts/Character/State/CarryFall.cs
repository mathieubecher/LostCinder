using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryFall : Fall
{
    public CarryFall(Controller character) : base(character)
    {

    }

    public override void Update()
    {
        if (character.GetComponent<SpriteRenderer>().flipX) character.cinder.transform.position = character.left.position;
        else character.cinder.transform.position = character.right.position;
        if (character.ground) character.activeState = new Carry(character);
        character.rigidbody.velocity = new Vector3(character.movement * character.speed, character.rigidbody.velocity.y);
    }
    public override string GetName()
    {
        return "CarryFall";
    }
    public override void fall() { }
    public override void shooting() { character.activeState = new Shoot(character); }
}
