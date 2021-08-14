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
        int x = 0;
        Cloth cloth;
        for (x = 0; x < IconList.Count; x++)
        {
            ItemControl itemcontrol = ItemGameObject[x].GetComponent<ItemControl>();
            itemcontrol.setIcon(IconList[x]);

            cloth = new Cloth(SpritList[y], SpritList[y + 1], types[x], 1, 1);
            Item item = new Item(cloth);
            ItemList.Add(item);
            itemcontrol.setItem(item);
            y = y + 2;
        }
        ItemGameObject[x].GetComponent<SpriteRenderer>().sprite = null;


    }

    public void receiveItem(ItemControl itemControl)
    {

        ItemList.Add(itemControl.getItem());
        SpritList.Add(itemControl.getItem().GetCloth().getFront());
        SpritList.Add(itemControl.getItem().GetCloth().getBack());
        IconList.Add(itemControl.icon);
        types.Add(itemControl.getItem().GetCloth().getModel());
    }

    public void updateInventory()
    {
        if (ItemList.Count < 6)
        {
            makeInventory();
        }
        else
        {
            Debug.Log("Inventario Cheio");
        }
    }

    public void removeFromInventory(ItemControl itemControl)
    {

        ItemList.Remove(itemControl.getItem());
        SpritList.Remove(itemControl.getItem().GetCloth().getFront());
        SpritList.Remove(itemControl.getItem().GetCloth().getBack());
        IconList.Remove(itemControl.icon);
        types.Remove(itemControl.getItem().GetCloth().getModel());
        itemControl.name = "empyt";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
