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
        ItemList = new List<Item>();
        int y = 0;
        Cloth cloth;
        for (int x = 0; x < IconList.Count; x++)
        {
            ItemControl itemcontrol = ItemGameObject[x].GetComponent<ItemControl>();
            itemcontrol.setId(x);
            itemcontrol.setIcon(IconList[x]);
            itemcontrol.setId(x);

            cloth = new Cloth(SpritList[y], SpritList[y + 1], types[x], 1, 1);
            Item item = new Item(cloth);
            ItemList.Add(item);
            itemcontrol.setItem(item);
            y = y + 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
