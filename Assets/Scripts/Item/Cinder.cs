using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinder : Item
{
    
    
    // Start is called before the first frame update
    protected override void Start()
    {
        UpdateSize();
        weight = P1;
    }

    // Update is called once per frame
    protected override void Update()
    {
        UpdateSize();
        base.Update();
    }
    public override void UpdateSize()
    {
        base.UpdateSize();
        transform.localScale = new Vector3(1, 1, 1) * weight;
    }
    
}
