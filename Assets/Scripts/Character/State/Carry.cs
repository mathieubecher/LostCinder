using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Carry : State
{
    private float deplacement = 0;
    private float last;
    public Carry(Controller character) : base(character)
    {
        character.cinder.GetComponent<Collider2D>().isTrigger = true;
        character.cinder.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        character.rigidbody.mass = 1 + character.cinder.weight;
        character.stateName.text = GetIdentifiant() + " Iddle";
        last = character.transform.position.x;
    }
    public override void Update()
    {
        carryCinder();
        character.rigidbody.velocity = new Vector3(MovementCinder(character.movement * character.speed), character.rigidbody.velocity.y);

        if (character.movement != 0)
        {
            deplacement += Math.Abs(character.transform.position.x - last);

            if (deplacement > 0.8f)
            {
                deplacement = 0;
                character.source.PlayOneShot(character.deplacement[UnityEngine.Random.Range(0, character.deplacement.Count)], 1);
            }

        }
        last = character.transform.position.x;

    }
    public override string GetIdentifiant()
    {
        return "Carry";
    }
    public override void jump() { if(character.cinder.weight< Item.P2)character.activeState = new CarryJump(character); }
    public override void carry() { character.activeState = new Iddle(character); }
    public override void fall() { character.activeState = new CarryFall(character); }
    public override void shooting() { character.activeState = new Shoot(character); }
}
