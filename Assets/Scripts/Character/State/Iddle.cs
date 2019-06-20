using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iddle : State
{
    public Iddle(Controller character) : base(character)
    {
        character.animator.SetBool("Squat", false);
        if (character.cinder != null)
        {
            character.cinder.GetComponent<Collider2D>().isTrigger = false;
            character.cinder.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }


        character.rigidbody.mass = 1;
        character.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.25f);
        character.GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 0.5f);
    }

    public override string GetIdentifiant()
    {
        if (character.movement != 0)
        {
            return "Move";
        }
        else return "Iddle";
    }

    public override void Update()
    {
        character.stateName.text = GetIdentifiant();
        character.rigidbody.velocity = new Vector3(character.movement * character.speed, character.rigidbody.velocity.y);
    }
    
    public override void jump() { character.activeState = new Jump(character); }
    public override void squat() { character.activeState = new Squat(character); }
    public override void carry() { character.activeState = new Carry(character); }
    public override void shooting() { if(character.pushCinder != null)character.activeState = new Hold(character); }
}
