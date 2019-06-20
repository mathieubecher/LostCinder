using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryJump : Jump
{
    private bool beginjump = false;
    public CarryJump(Controller character) : base(character)
    {
        character.source.PlayOneShot(character.saut, 0.5f);
        character.stateName.text = GetIdentifiant() + " Jump";
    }
    public override string GetIdentifiant()
    {
        return "Carry";
    }


    public override void Update()
    {
        carryCinder();
        if (!beginjump && character.rigidbody.velocity.y > 0) beginjump = true;
        if (beginjump && character.ground && character.rigidbody.velocity.y <= 0)  character.activeState = new Carry(character);
        character.rigidbody.velocity = new Vector3(MovementCinder(MovementJump(character.movement * character.speed)), character.rigidbody.velocity.y);
    }
    public override void fall() { character.activeState = new CarryFall(character); }
    public override void shooting() { character.activeState = new Shoot(character); }
}
