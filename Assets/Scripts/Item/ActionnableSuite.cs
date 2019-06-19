using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionnableSuite : Actionnable
{
    public Actionnable action;

    protected override void Update()
    {
        base.Update();
        if(timer >= time)
        {
            action.Action();
        }
    }
}
