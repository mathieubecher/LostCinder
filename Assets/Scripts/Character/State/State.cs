using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class State
{
    public static float jumpSpeed = 1;
    public float MovementJump(float movement)
    {
        return movement * jumpSpeed;
    }
    public float MovementCinder(float movement)
    {
        return movement / (1 + character.cinder.weight);
    }
    public float MovementPush(float movement)
    {
        return movement / (1 + character.pushCinder.weight);
    }
    public void carryCinder()
    {
        Vector3 direction = (character.cinder.weight>= Item.P2)?character.P2pos.transform.localPosition:character.P1pos.transform.localPosition;
        if (character.GetComponent<SpriteRenderer>().flipX) direction.x *= -1;
        character.cinder.transform.position = direction+character.transform.position;
    }


    protected Controller character;

    public State(Controller character)
    {
        this.character = character;
        character.stateName.text = GetIdentifiant();
    }

    public virtual string GetIdentifiant()
    {
        return "State";
    }

    public virtual void Update() { }
    public virtual void move() { }
    public virtual void iddle() { }
    public virtual void jump() { }
    public virtual void squat() { }
    public virtual void raise() { }
    public virtual void carry() { }
    public virtual void shooting() { }
    public virtual void shoot() { }
    public virtual void hold() { }
    public virtual void fall() { character.activeState = new Fall(character); }

}
