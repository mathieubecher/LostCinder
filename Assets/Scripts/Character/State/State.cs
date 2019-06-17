using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Controller character;

    public State(Controller character)
    {
        this.character = character;
        character.stateName.text = GetName();
    }

    public virtual string GetName()
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
    public virtual void fall() { character.activeState = new Fall(character); }

}
