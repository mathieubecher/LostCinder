using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPush : MonoBehaviour
{
    public Controller character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger && character.pushCinder == null)
        {
            Debug.Log(other.gameObject.name);
            character.pushCinder = other.gameObject.GetComponent(typeof(Item)) as Item;
        }
            
    }
}
