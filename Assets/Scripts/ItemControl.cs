using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    public MouseControl control;
    public Item item;
    public SpriteRenderer icon;
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
        transform.position = position;
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
        
    }

    void OnMouseDrag()
    {
        control.HoldItem(gameObject);
    }

    void OnMouseUp()
    {
        control.DropItem();
    }
}
