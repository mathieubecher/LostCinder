using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform follow;
    public float strength = 2;

    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        UpdateFrontier();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = (follow.position - transform.position)*strength;
    }
    void UpdateFrontier()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Debug.Log(width + " " + height);
        BoxCollider2D[] frontiers = GetComponents<BoxCollider2D>();

        // LEFT
        frontiers[0].offset = new Vector2(-width/2 - 1,0);
        frontiers[0].size = new Vector2(2, height + 2);
        // RIGHT
        frontiers[1].offset = new Vector2(width / 2 + 1, 0);
        frontiers[1].size = new Vector2(2, height + 2);
        // TOP
        frontiers[2].offset = new Vector2(0, -height / 2 - 1);
        frontiers[2].size = new Vector2(width + 2, 2);
        // BOTTOM
        frontiers[3].offset = new Vector2(0, height / 2 + 1);
        frontiers[3].size = new Vector2(width + 2, 2);

    }
}
