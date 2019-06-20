using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableJoint : Actionner
{

    public AudioClip activate;

    public override void Action()
    {
        Debug.Log("Action");
        if (!begin)
        {
            Destroy(GetComponent<HingeJoint2D>());
            begin = true;
            if (action != null) action.Action();
            GetComponent<AudioSource>().PlayOneShot(activate, 1);
        }

    }
}
