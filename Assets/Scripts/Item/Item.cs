﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static float P1 = 0.5f;
    public static float P2 = 0.8f;
    public static float P3 = 1f;
    public Controller character;
    public bool detect;
    public float weight = 0.5f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        UpdateSize();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //UpdateSize();
        if (character != null)
        {
            if (!detect && character.activeState.GetIdentifiant() != "Carry")
            {
                //Debug.Log(character.activeState.GetIdentifiant() + " " + character.activeState.GetType());

                character.cinder = null;
                character = null;
            }
        }
        else detect = false;
    }
    public virtual void UpdateSize()
    {
        GetComponent<Rigidbody2D>().mass = weight * 2000;
        //transform.localScale = new Vector3(1, 1, 1) * weight;
        if (weight >= P3) gameObject.layer = 12;
        else if (weight >= P2) gameObject.layer = 11;
        else gameObject.layer = 10;

    }
}