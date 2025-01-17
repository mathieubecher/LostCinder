﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public Item parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(parent.character != null)
            parent.detect = parent.character.activeState.GetIdentifiant() == "Shoot" || parent.character.activeState.GetIdentifiant() == "Carry" || GetComponent<Collider2D>().Distance(parent.character.GetComponent<Collider2D>()).distance < 0;
            
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(parent.weight < Item.P3 && parent.character == null) { 
            parent.character = other.gameObject.GetComponent(typeof(Controller)) as Controller;
            try
            {
                if (parent.character.cinder == null)
                {
                    parent.character.cinder = parent;
                    parent.detect = true;
                }
                else
                {
                    parent.character = null;
                    Debug.Log("ça sort");
                }
            }
            catch
            {
                Debug.Log(parent.character);
            }
        }
    }
}
