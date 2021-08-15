using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public GameObject clickedItem;
    public bool isHolding;
    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            clickedItem.transform.position = position;
        } 
    }


    //sets the boolean for dragging the item with the cursor
    public void HoldItem(GameObject clickedOn)
    {
        clickedItem = clickedOn;
        clickedItem.GetComponent<BoxCollider2D>().isTrigger = false;
        clickedItem.GetComponent<BoxCollider2D>().enabled = false;
        isHolding = true;
    }

    //drops the item and gives it a boxcollider2d(not trigger) for a delay of 0.1f
    public void DropItem()
    {
        clickedItem.GetComponent<BoxCollider2D>().enabled = true;
        isHolding = false;
        float delay = 0.1f;
        Invoke("ResetItem", delay);
    }

    //resets the original position of a item on the screen
    public void ResetItem()
    {
        if (!clickedItem.name.Contains("emp"))
            clickedItem.GetComponent<BoxCollider2D>().isTrigger = true;
        clickedItem.GetComponent<ItemControl>().resetPosition();
    }
}
