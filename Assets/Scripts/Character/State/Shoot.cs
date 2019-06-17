using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : State
{
    Vector2 direction;
    private float STRENGHT = 400;
    private LineRenderer lineRender;
    private GameObject line;

    public Shoot(Controller character) : base(character)
    {

        character.click = true;
        character.pointer.SetActive(true);
        CreateLine();
        UpdatePointerPos();
        
    }
    public override string GetName()
    {
        return "Shoot";
    }

    public override void Update()
    {
        character.rigidbody.velocity = new Vector3(0, character.rigidbody.velocity.y);
        // maj ground detect
        if (character.gameObject.layer != 8 && character.rigidbody.velocity.y < 0) character.gameObject.layer = 8;

        if (character.GetComponent<SpriteRenderer>().flipX) character.cinder.transform.position = character.left.position;
        else character.cinder.transform.position = character.right.position;
        UpdatePointerPos();
    }

    public void UpdatePointerPos()
    {
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.character.transform.position);
        direction.Normalize();
        character.pointer.transform.localPosition = direction*2;

        Vector3[] positions = new Vector3[2];
        positions[0] = character.transform.position;
        positions[1] = character.pointer.transform.position;
        this.lineRender.SetPositions(positions);
    }
    public override void shoot()
    {
        character.click = false;
        character.pointer.SetActive(false);
        character.activeState = new Iddle(character);
        GameObject.Destroy(this.line);
        character.cinder.GetComponent<Rigidbody2D>().AddForce(direction * STRENGHT);
    }
    public override void fall() { }

    public void CreateLine()
    {
        float lineWidth = 0.2f;
        Vector3[] positions = new Vector3[2];
        positions[0] = character.transform.position;
        positions[1] = character.pointer.transform.position;

        this.line = new GameObject();
        //myLine.transform.position = start;
        this.line.AddComponent<LineRenderer>();
        this.lineRender = this.line.GetComponent<LineRenderer>();
        this.lineRender.material.color = Color.white;
        this.lineRender.SetColors(new Color(1,1,1,0), Color.white);
        this.lineRender.SetWidth(lineWidth, lineWidth);
        this.lineRender.SetPositions(positions);
        this.lineRender.material = character.line;
    }
}
