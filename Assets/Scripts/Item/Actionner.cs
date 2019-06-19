using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actionner : Actionnable
{
    public Actionnable action;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
       
        base.Update();
    }
    public override void Action()
    {

        if(!begin || revertable) { 
            base.Action();
            if(action != null) action.Action();
        }

    }
    

}
