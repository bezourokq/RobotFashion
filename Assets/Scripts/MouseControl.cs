using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public GameObject clickedItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Held");
        }
        else
        {
            Debug.Log("Not held");
        }
    }

    public void HoldItem(GameObject clickedOn)
    {
       

        clickedItem = clickedOn;
        //clickedItem.transform.position = Input.mousePosition;
        clickedItem.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clickedItem.name = "cliked";
    }

    public void DropItem()
    {
        //clickedItem.name = "uncliked";
    }
}
