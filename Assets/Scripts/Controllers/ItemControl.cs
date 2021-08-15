using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public MouseControl control;
    public Item item;
    public int id;
    Vector3 position;
    Quaternion rotation;
    // Start is called before the first frame update

    //gets the initial position of the object
    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
    }
    //resets the object position
    public void resetPosition()
    {
        transform.position = transform.parent.position;
        transform.rotation = rotation;
    }

    public Item getItem()
    {
        return item;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public void setIcon(Sprite icon)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = icon;
    }

    public void setItem(Item item)
    {
        this.item = item;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name.Contains("emp"))
        {
            position = transform.position;
        }
    }

    //Mouse hold/drag
    void OnMouseDrag()
    {
        control.HoldItem(gameObject);
    }

    //Mouse up
    void OnMouseUp()
    {
        control.DropItem();
    }


    //Drag and drop main code, here the item that is bein drag gets to what end is his purpose
    private void OnCollisionEnter2D(Collision2D Collider)
    {
        GameObject temp = Collider.gameObject;
        Debug.Log(temp.name);
        if (temp.name.Contains("emp") && gameObject.name.Contains("Full"))
        {

            InventoryControl inventory = GameObject.Find("inventory").GetComponent<InventoryControl>();
            inventory.receiveItem(gameObject.GetComponent<ItemControl>().getItem());
            GameObject.Find("Player").GetComponent<PlayerControl>().setMoney(-20);
        }
        else if (temp.name == "Delete" && gameObject.name.Contains("bought"))
        {

            gameObject.GetComponent<SpriteRenderer>().sprite = null;
            InventoryControl inventory = GameObject.Find("inventory").GetComponent<InventoryControl>();
            inventory.removeFromInventory(gameObject.GetComponent<ItemControl>().getItem());

            temp.GetComponent<BoxCollider2D>().isTrigger = false;
            GameObject.Find("Player").GetComponent<PlayerControl>().setMoney(10);
        }
    }

    //helps making the list work, if an item box is empty it is not a trigger and has no sprite
    private void FixedUpdate()
    {
        if (gameObject.name.Contains("emp"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
           
    }

}
