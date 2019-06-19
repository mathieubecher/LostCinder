using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryJump : Jump
{
    public CarryJump(Controller character) : base(character)
    {
        character.stateName.text = GetIdentifiant() + " Jump";
    }
    public override string GetIdentifiant()
    {
        return "Carry";
    }


    public override void Update()
    {
        carryCinder();
        if (character.ground) character.activeState = new Carry(character);
        character.rigidbody.velocity = new Vector3(MovementCinder(MovementJump(character.movement * character.speed)), character.rigidbody.velocity.y);
    }
    public override void fall() { character.activeState = new CarryFall(character); }
    public override void shooting() { character.activeState = new Shoot(character); }
}
