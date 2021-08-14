using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    
    public List<GameObject> ItemGameObject;
    public ItemFactory iFactory;
    public int size;

    void Start()
    {
        int x;
        iFactory.init();
        for (x = 0; x < size;x++)
        {
            Debug.Log(x);
            iFactory.MakeItem();
        }
        if(x > 0)
            makeInventory();
    }

    void makeInventory()
    {
        int x = 0;
        foreach (Item item in iFactory.GetItemList())
        {
            ItemGameObject[x].name = "bought";
            ItemGameObject[x].gameObject.GetComponent<ItemControl>().setId(x);
            ItemGameObject[x].gameObject.GetComponent<ItemControl>().setIcon(item.getIcon());
            x++;
        }



    }

    public void receiveItem(ItemControl itemControl)
    {


    }

    public void updateInventory()
    {
        
    }

    public void removeFromInventory(ItemControl itemControl)
    {

      

    }

}
