using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public Cloth clothItem;
    public Sprite icon;
    
    // Start is called before the first frame update

    public Item(Cloth clothItem,Sprite icon)
    {
        this.clothItem = clothItem;
        this.icon = icon;
    }

    public Cloth getCloth()
    {
        return clothItem;
    }
    public Sprite getIcon()
    {
        return icon;
    }
}
