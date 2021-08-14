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

    public void init()
    {
        ItemList = new List<Item>();
    }
    public void AddToList(Item item)
    {
        ItemList.Add(item);
    }

    public void MakeItem()
    {
        Cloth cloth = new Cloth(SpritList[y], SpritList[y + 1], types[x], 1, 1);
        Item item = new Item(cloth, IconList[x]);
        x++;
        y = y + 2;

        ItemList.Add(item);
    }

    public int getMax()
    {
        return max;
    }

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
