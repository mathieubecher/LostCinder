using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableItem : Actionnable

{
    public List<Rigidbody2D> freezes;

    public override void Action()
    {
        foreach(Rigidbody2D r in freezes)
        {
            r.constraints = RigidbodyConstraints2D.None;
        }
        GetComponent<Collider2D>().isTrigger = true;
    }
}
