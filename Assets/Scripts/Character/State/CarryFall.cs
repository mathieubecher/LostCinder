using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryFall : Fall
{
    public CarryFall(Controller character) : base(character)
    {
        character.stateName.text = GetIdentifiant() + " Fall";
    }

    public override void Update()
    {
        carryCinder();
        if (character.ground) character.activeState = new Carry(character);
        character.rigidbody.velocity = new Vector3(MovementCinder(MovementJump(character.movement * character.speed)), character.rigidbody.velocity.y);
    }
    public override string GetIdentifiant()
    {
        return "Carry";
    }
    public override void fall() { }
    public override void shooting() { character.activeState = new Shoot(character); }
}
