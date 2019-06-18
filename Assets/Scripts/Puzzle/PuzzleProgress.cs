using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    LEFTRIGHT, RIGHTLEFT, TOPDOWN, DOWNTOP
}

public class PuzzleProgress : MonoBehaviour
{
    public Puzzle parent;
    public Transform begin;
    public Transform end;
    public float progress;
    public Direction progressDirection = Direction.LEFTRIGHT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
