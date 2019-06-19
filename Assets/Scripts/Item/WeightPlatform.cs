using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightPlatform : Actionner
{
    public Collider2D trigger;
    private List<Item> allItem;
    private Controller character = null;
    public float maxWeight = 2;

    // Start is called before the first frame update
    protected override void Start()
    {
        allItem = new List<Item>();
        base.Start();
        trigger = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        int i = 0;
        while(i<allItem.Count)
        {
            if (trigger.Distance(allItem[i].GetComponent<Collider2D>()).distance > 0)
            {
                RemoveItem(allItem[i]);
            }
            else i++;
        }
        if (character != null && trigger.Distance(character.GetComponent<Collider2D>()).distance > 0) character = null;
        float weight = GetWeight();
        if((weight > maxWeight && !begin) || (weight <= maxWeight && begin))
        {
            Action();
        }

        base.Update();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Object")
        {
            try
            {
                Item item = other.gameObject.GetComponent(typeof(Item)) as Item;
                allItem.Add(item);
            }
            catch { }
        }
        else if(other.tag == "Player")
        {
            try
            {
                Controller c = other.gameObject.GetComponent(typeof(Controller)) as Controller;
                character = c;

            }
            catch { }
        }
    }

    private float GetWeight()
    {
        float weight = 0;
        foreach(Item item in allItem)
        {
            weight += item.weight;
        }
        if (character != null) ++weight;
        return weight;
    }
    private void RemoveItem(Item item)
    {
        allItem.Remove(item);
    }
}
