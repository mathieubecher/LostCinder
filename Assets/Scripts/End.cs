using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public CameraController cam;
    public Controller character;
    public GameObject particlecinder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        cam.follow = character.transform;
        Cinder cinder = other.gameObject.GetComponent(typeof(Cinder)) as Cinder;
        Destroy(cinder.gameObject);
        Destroy(particlecinder);
        Debug.Log("object");
    }
}
