using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Actionner
{
    public LayerMask detector;
    private Collider2D touch;
    public AudioSource source;
    public AudioClip activate;
    public float value = 1;

    protected override void Start()
    {
        base.Start();
        source = GetComponent<AudioSource>();
    }
    protected override void Update()
    {
        if (revertable && begin && touch != null && GetComponent<Collider2D>().Distance(touch).distance > 0)
        {
            //Debug.Log("active");
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
                Debug.Log(other.gameObject.name);
                touch = other;
                Action();
                source.PlayOneShot(activate, value);
            }
        }
    }
}
