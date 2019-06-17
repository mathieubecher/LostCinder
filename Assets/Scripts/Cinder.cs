using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinder : MonoBehaviour
{
    public float P1 = 0.5f;
    public float P2 = 0.8f;
    public float P3 = 1f;

    public Controller character;
    public bool detect;
    public float weight = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        weight = P1;
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
