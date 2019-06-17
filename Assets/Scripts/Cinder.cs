using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinder : MonoBehaviour
{
    public Controller character;
    public bool detect;
    public float weight = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSize();
        detect = GetComponent<Collider2D>().Distance(character.GetComponent<Collider2D>()).distance < 0;
    }
    public void UpdateSize()
    {
        GetComponent<Rigidbody2D>().mass = weight*2;
        transform.localScale = new Vector3(1, 1, 1) * weight;
    }
}
