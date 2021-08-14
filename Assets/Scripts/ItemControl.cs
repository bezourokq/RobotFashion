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
    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
    }

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

    void OnMouseDrag()
    {
        control.HoldItem(gameObject);
    }

    void OnMouseUp()
    {
        control.DropItem();
    }

    private void OnCollisionEnter2D(Collision2D Collider)
    {
        GameObject temp = Collider.gameObject;

        if (temp.name.Contains("emp") && gameObject.name.Contains("Full"))
        {
            InventoryModel inventory = GameObject.Find("inventory").GetComponent<InventoryModel>();
            Debug.Log(gameObject.GetComponent<ItemControl>().getItem());
            inventory.receiveItem(gameObject.GetComponent<ItemControl>().getItem());
        }
        else if(temp.name == "Delete" && gameObject.name.Contains("Brought"))
        {
            InventoryModel inventory = GameObject.Find("inventory").GetComponent<InventoryModel>();
            inventory.removeFromInventory(gameObject.GetComponent<ItemControl>().getItem());
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
            temp.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
