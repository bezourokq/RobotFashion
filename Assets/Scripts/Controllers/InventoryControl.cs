using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    
    public List<GameObject> ItemGameObject;
    List<GameObject> CopyItemGameObject;
    public ItemFactory iFactory;
    public int size;
    int totalItem;
    public string name;


    //run the list of items from the factory and build the shop
    void Start()
    {
        CopyItemGameObject = ItemGameObject;
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

    //run the list of items from the factory and build the inventory
    void makeInventory()
    {
        int x = 0;
        cleanInventory();
        foreach (Item item in iFactory.GetItemList())
        {
            Debug.Log("Adicionando " + x);
            ItemGameObject[x].name = name;
            ItemGameObject[x].GetComponent<ItemControl>().setItem(item);
            ItemGameObject[x].GetComponent<ItemControl>().setId(x);
            ItemGameObject[x].gameObject.GetComponent<ItemControl>().setId(x);
            ItemGameObject[x].gameObject.GetComponent<ItemControl>().setIcon(item.getIcon());
            x++;
        }
    }

    //adds a nem item to the factory list
    public void receiveItem(Item item)
    {
        totalItem = totalItem + 1;
        if(totalItem < iFactory.getMax())
        {
            iFactory.AddToList(item);
            makeInventory();
        }
        else
        {
            Debug.Log("Inventory is full");
        }
    }

    //this i dont think is doing anything, i tried solving a bug on the list and the bug is gonne so i let the code be
    public void cleanInventory()
    {
        ItemGameObject = CopyItemGameObject;
    }

    //remove a item from the factory item list
    public void removeFromInventory(Item item)
    {
        Debug.Log("WTF");
        iFactory.RemoveFromList(item);
        ItemGameObject[totalItem - 1].name = "empty";
        makeInventory();
        totalItem = totalItem - 1;
    }

}
