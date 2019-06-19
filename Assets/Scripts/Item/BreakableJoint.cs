using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableJoint : Actionner
{
    public override void Action()
    {

        if (!begin)
        {
            Destroy(GetComponent<DistanceJoint2D>());
            begin = true;
            if (action != null) action.Action();
        }

    }
}
