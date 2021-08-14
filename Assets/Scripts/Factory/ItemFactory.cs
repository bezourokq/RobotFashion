using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public List<Item> ItemList;
    public List<Sprite> SpritList;
    public List<Sprite> IconList;
    public List<int> types;
    int max = 0, y = 0;

    public void init()
    {
        ItemList = new List<Item>();
    }

    public void MakeItem()
    {
        Cloth cloth = new Cloth(SpritList[y], SpritList[y + 1], types[max], 1, 1);
        Item item = new Item(cloth, IconList[max]);
        max++;
        y = y + 2;

        ItemList.Add(item);
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
