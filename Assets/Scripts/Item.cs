using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public MouseControl control;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("control").GetComponent<MouseControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDrag()
    {
        control.HoldItem(gameObject);
    }

    void OnMouseUp()
    {
        control.DropItem();
    }
}
