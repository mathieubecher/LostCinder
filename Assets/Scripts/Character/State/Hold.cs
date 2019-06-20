using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Hold : State
{
    float ecart = 0;
    public Hold(Controller character) : base(character)
    {
        character.click = true;
        ecart = character.transform.position.x-character.pushCinder.transform.position.x;
        character.GetComponent<SpriteRenderer>().flipX = ecart > 0;
    }
    public override void Update()
    {

        if(character.pushCinder != null && Math.Abs(character.pushCinder.GetComponent<Rigidbody2D>().velocity.x) < MovementPush(character.speed)) {
            Debug.Log(MovementPush(character.speed) + " " + Math.Abs(character.pushCinder.GetComponent<Rigidbody2D>().velocity.x)+ " " + character.movement);
            
            Vector3 velocityCinder = character.pushCinder.GetComponent<Rigidbody2D>().velocity;
            if (Math.Abs(velocityCinder.x ) < Math.Abs(MovementPush(character.movement * character.speed))*0.5f) {
                velocityCinder.x += MovementPush(character.movement * character.speed)/ 4f;
                character.pushCinder.GetComponent<Rigidbody2D>().velocity = velocityCinder;
            }
            character.transform.position = new Vector3(character.pushCinder.transform.position.x + ecart, character.transform.position.y);

        }
        else
        {
            character.activeState = new Iddle(character);
        }
    }
    public override string GetIdentifiant()
    {
        return "Hold";
    }

    public override void jump() { character.activeState = new Jump(character); }
    public override void squat() { character.activeState = new Squat(character); }
    public override void carry() { character.activeState = new Carry(character); }
    public override void shoot() { character.click = false; character.activeState = new Iddle(character); }
}
