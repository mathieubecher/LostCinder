using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum Direction
{
    horizontal, vertical
}

public class PuzzleProgress : MonoBehaviour
{
    public Puzzle parent;
    public Transform begin;
    public Transform end;

    public float beginWeight;
    public float endWeight;

    public float progress;
    public Direction progressDirection = Direction.horizontal;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCinder()
    {
        Vector3 playerpos = parent.character.transform.position;
        float actualProgress = (progressDirection == Direction.horizontal)?Math.Abs((parent.character.transform.position.x - begin.position.x) / (end.position.x - begin.position.x)):
            Math.Abs((parent.character.transform.position.y - begin.position.y) / (end.position.y - begin.position.y));
        if (actualProgress > progress && actualProgress <= 1 && actualProgress >= 0)
        {
            progress = actualProgress;
            parent.cinder.weight = beginWeight + (endWeight - beginWeight) * progress;
        }
        else if(actualProgress > 1)
        {
            progress = 1;
        }
    }

}
