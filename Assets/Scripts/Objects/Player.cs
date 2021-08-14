using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Cloth UpperBody, LowerBody;
    //inventory
    //cloths
    public Player()
    {

    }

    public Player(Cloth UpperBody, Cloth LowerBody)
    {
        this.UpperBody = UpperBody;
        this.LowerBody = LowerBody;
    }


    public void ChangeCloth(Cloth cloth)
    {

    }
}
