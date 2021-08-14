using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public MouseControl control;
    public Item item;
    public Sprite icon;
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
        transform.position = position;
        transform.rotation = rotation;
    }

    public Item getItem()
    {
        return item;
    }

    public void setIcon(Sprite icon)
    {
        this.icon = icon;
        gameObject.GetComponent<SpriteRenderer>().sprite = icon;
    }

    public void setItem(Item item)
    {
        this.item = item;
    }

    // Update is called once per frame
    void Update()
    {

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
        if (temp.name.Contains("empyt"))
        {
            Debug.Log("entrei");
            InventoryModel inventory = GameObject.Find("inventory").GetComponent<InventoryModel>();
            inventory.receiveItem(item, item.GetCloth().getFront(), item.GetCloth().getBack(), icon, item.GetCloth().getModel());
            inventory.updateInventory();


        }
    }
}
