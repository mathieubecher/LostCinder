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
        Debug.Log(GetName());
    }

    public virtual string GetName()
    {
        return "State";
    }

    public virtual void Update() { }
    public virtual void Move() { }
    public virtual void Iddle() { }
    public virtual void Jump() { }
    public virtual void Squat() { }
    public virtual void Raise() { }
    public virtual void Fall() { character.activeState = new Fall(character); }

}
