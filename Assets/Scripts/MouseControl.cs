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

    public void HoldItem(GameObject clickedOn)
    {
        clickedItem = clickedOn;
        clickedItem.GetComponent<BoxCollider2D>().isTrigger = false;
        clickedItem.GetComponent<BoxCollider2D>().enabled = false;
        isHolding = true;
    }

    public void DropItem()
    {
        clickedItem.GetComponent<BoxCollider2D>().enabled = true;
        isHolding = false;
    }
}
