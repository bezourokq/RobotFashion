using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    
    public List<GameObject> ItemGameObject;
    public ItemFactory iFactory;
    public int size;
    int totalItem;
    public string name;
    

    void Start()
    {
        totalItem = 0;
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
            ItemGameObject[x].name = name;
            ItemGameObject[x].GetComponent<ItemControl>().setItem(item);
            ItemGameObject[x].GetComponent<ItemControl>().setId(x);
            ItemGameObject[x].gameObject.GetComponent<ItemControl>().setId(x);
            ItemGameObject[x].gameObject.GetComponent<ItemControl>().setIcon(item.getIcon());
            x++;
        }
    }

    public void receiveItem(Item item)
    {
        totalItem = totalItem + 1;
        if(totalItem < iFactory.getMax())
        {
            Debug.Log(item);
            iFactory.AddToList(item);
            makeInventory();
        }
        else
        {
            Debug.Log("Inventorio Cheio");
        }
    }


    public void removeFromInventory(Item itemControl)
    {

    }

}
