using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryJump : Jump
{
    public CarryJump(Controller character) : base(character)
    {
    }
    public override string GetName()
    {
        return "CarryJump";
    }


    public override void Update()
    {
        if (character.GetComponent<SpriteRenderer>().flipX) character.cinder.transform.position = character.left.position;
        else character.cinder.transform.position = character.right.position;
        character.rigidbody.velocity = new Vector3(MovementCinder(MovementJump(character.movement * character.speed)), character.rigidbody.velocity.y);
    }
    public override void fall() { character.activeState = new CarryFall(character); }
    public override void shooting() { character.activeState = new Shoot(character); }
}
