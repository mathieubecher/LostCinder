using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Actionner
{
    public LayerMask detector;
    private Collider2D touch;


    protected override void Update()
    {
        if (revertable && begin && touch != null && GetComponent<Collider2D>().Distance(touch).distance > 0)
        {
            Action();
            touch = null;
        }
        base.Update();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(detector == (detector | (1 << other.gameObject.layer)) && !other.isTrigger )
        {
            if (!begin)
            {
                touch = other;
                Action();
            }
        }
    }
}
