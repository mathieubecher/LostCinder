using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableItem : Actionnable

{
    public override void Action()
    {
        Destroy(this.gameObject);
    }
}
