using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemFactory : MonoBehaviour
{
    public List<Item> ItemList;
    public List<Sprite> SpritList;
    public List<Sprite> IconList;
    public List<int> types;
    int x = 0, y = 0;
    public int max;

    //creat a new empyt item list
    public void init()
    {
        ItemList = new List<Item>();
    }

    //ad a new item to the list
    public void AddToList(Item item)
    {
        x++;
        y = y + 2;
        ItemList.Add(item);
    }

    //remove a item from the list
    public void RemoveFromList(Item item)
    {
        ItemList.Remove(item);
        x--;
        y = y - 2;
    }

    //makes brand new item and adds to the list
    public void MakeItem()
    {
        Cloth cloth = new Cloth(SpritList[y], SpritList[y + 1], types[x], 1, 1);
        Item item = new Item(cloth, IconList[x]);
        AddToList(item);
    }

    //get the max value of items on a list
    public int getMax()
    {
        return max;
    }

    //return the list
    public List<Item> GetItemList()
    {
        return ItemList;
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
