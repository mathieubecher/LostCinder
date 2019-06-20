using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Iddle : State
{
    private float deplacement = 0;
    private float last;
    public Iddle(Controller character) : base(character)
    {
        
        
        if (character.cinder != null)
        {
            character.cinder.GetComponent<Collider2D>().isTrigger = false;
            character.cinder.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

        last = character.transform.position.x;
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
        if (character.movement != 0)
        {
            deplacement += Math.Abs(character.transform.position.x - last);

            if (deplacement > 1f)
            {
                deplacement = 0;
                character.source.PlayOneShot(character.deplacement[UnityEngine.Random.Range(0, character.deplacement.Count)], 1);
            }

        }
        last = character.transform.position.x;
    }
    
    public override void jump() { character.activeState = new Jump(character); }
    public override void squat() { character.activeState = new Squat(character); }
    public override void carry() { character.activeState = new Carry(character); }
    public override void shooting() { if(character.pushCinder != null)character.activeState = new Hold(character); }
}
