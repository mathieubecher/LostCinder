using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : State
{
    Vector2 direction;
    private float STRENGHT = 400;

    public Shoot(Controller character) : base(character)
    {
        character.click = true;
        character.pointer.SetActive(true);
        UpdatePointerPos();
    }
    public override string GetName()
    {
        return "Shoot";
    }

    public override void Update()
    {
        if (character.GetComponent<SpriteRenderer>().flipX) character.cinder.transform.position = character.left.position;
        else character.cinder.transform.position = character.right.position;
        UpdatePointerPos();
    }

    public void UpdatePointerPos()
    {
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.character.transform.position);
        direction.Normalize();
        character.pointer.transform.localPosition = direction;
    }
    public override void shoot()
    {
        character.click = false;
        character.pointer.SetActive(false);
        character.activeState = new Iddle(character);
        character.cinder.GetComponent<Rigidbody2D>().AddForce(direction * STRENGHT);
    }
    public override void fall() { }
}
