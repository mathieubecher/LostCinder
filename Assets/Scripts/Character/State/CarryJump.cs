using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryJump : Jump
{
    public CarryJump(Controller character) : base(character)
    {
        character.stateName.text = GetName() + " Jump";
    }
    public override string GetName()
    {
        return "Carry";
    }


    public override void Update()
    {
        carryCinder();
        character.rigidbody.velocity = new Vector3(MovementCinder(MovementJump(character.movement * character.speed)), character.rigidbody.velocity.y);
    }
    public override void fall() { character.activeState = new CarryFall(character); }
    public override void shooting() { character.activeState = new Shoot(character); }
}
