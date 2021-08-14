using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth
{

    public Sprite front,back;
    public int Model = 0;
    public float priceBuy = 0f;
    public float priceSell = 0f;
    // Start is called before the first frame update

    public Cloth(Sprite front,Sprite back,int Model, float priceBuy, float priceSell)
    {
        this.front = front;
        this.back = back;
        this.Model = Model;
        this.priceBuy = priceBuy;
        this.priceSell = priceSell;

    }

    public Sprite getFront()
    {
        return front;
    }

    public Sprite getBack()
    {
        return back;
    }

    public int getModel()
    {
        return Model;
    }
}
