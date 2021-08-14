using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public Cloth clothItem;
    // Start is called before the first frame update

    public Item(Cloth clothItem)
    {
        this.clothItem = clothItem;
    }

    public Cloth GetCloth()
    {
        return clothItem;
    }
}
