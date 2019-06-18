using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puzzle : MonoBehaviour
{
    public int id = 0;
    public Controller character;
    public Cinder cinder;
    public PuzzleProgress progress;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Retry()
    {
        character.activeState = new Iddle(character);
        cinder.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        cinder.transform.position = progress.begin.position + new Vector3(1, 0, 0);
        character.rigidbody.velocity = new Vector3(0, 0);
        character.transform.position = progress.begin.position;
        
        
        progress.progress = 0;
    }
}
