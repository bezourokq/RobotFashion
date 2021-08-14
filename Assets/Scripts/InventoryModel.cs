using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    public List<Item> ItemList;
    public List<Sprite> SpritList;
    public List<GameObject> ItemGameObject;
    public List<Sprite> IconList;
    public List<int> types;

    // Start is called before the first frame update
    void Start()
    {
        makeInventory();
    }

    void makeInventory()
    {
        ItemList = new List<Item>();
        int y = 0;
        Cloth cloth;
        Debug.Log("-----");
        Debug.Log(IconList.Count);
        Debug.Log(SpritList.Count);
        for (int x = 0; x < IconList.Count; x++)
        {
            ItemControl itemcontrol = ItemGameObject[x].GetComponent<ItemControl>();
            itemcontrol.setIcon(IconList[x]);

            cloth = new Cloth(SpritList[y], SpritList[y + 1], types[x], 1, 1);
            Item item = new Item(cloth);
            ItemList.Add(item);
            itemcontrol.setItem(item);
            y = y + 2;
        }

    }

    public void receiveItem(Item item,Sprite Front,Sprite Back,Sprite icon,int model)
    {
        ItemList.Add(item);
        SpritList.Add(Front);
        SpritList.Add(Back);
        IconList.Add(icon);
        types.Add(model);
    }

    public void updateInventory()
    {
        makeInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
