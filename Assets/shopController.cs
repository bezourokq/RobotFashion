using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopController : MonoBehaviour
{
    bool playerOn, showGoods;
    public GameObject store;
    // Start is called before the first frame update
    void Start()
    {
        showGoods = false;
        playerOn = false;
        store.SetActive(showGoods);
    }

    // Update is called once per frame if the playe press 'e' next to the npc the shop opens
    void Update()
    {
        if (Input.GetKeyDown("e") && playerOn)
        {
            showGoods = !showGoods;
            store.SetActive(showGoods);
        }
    }

    //detect the player close to the npc
    private void OnCollisionEnter2D(Collision2D Collider)
    {
        if(Collider.gameObject.name == "Player")
        {
            GameObject temp = Collider.gameObject;
            playerOn = true;
        }
        
    }

    //detects that the player left the npc
    private void OnCollisionExit2D(Collision2D Collider)
    {
        if (Collider.gameObject.name == "Player")
        {
            GameObject temp = Collider.gameObject;
            playerOn = false;
            showGoods = false;
            store.SetActive(showGoods);
        }
    }
}
