using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinder : MonoBehaviour
{
    public Controller character;
    public bool detect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detect = GetComponent<Collider2D>().Distance(character.GetComponent<Collider2D>()).distance < 0;
    }
}
