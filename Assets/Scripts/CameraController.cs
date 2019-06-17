using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 last;
    public Transform follow;
    public float strength = 2;

    private Rigidbody2D rigidbody;
    private Vector2 resolution;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        resolution = new Vector2(Screen.width, Screen.height);
        UpdateFrontier();
        last = new Vector3(follow.transform.position.x, follow.transform.position.y, follow.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            UpdateFrontier();
            resolution.x = Screen.width;
            resolution.y = Screen.height;
        }

        if(last != follow.transform.position)
        {
            rigidbody.velocity = (follow.position - transform.position) * strength*5;
        }
        else rigidbody.velocity = (follow.position - transform.position)*strength;
        last = new Vector3(follow.transform.position.x, follow.transform.position.y, follow.transform.position.z);
    }
    void UpdateFrontier()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
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
