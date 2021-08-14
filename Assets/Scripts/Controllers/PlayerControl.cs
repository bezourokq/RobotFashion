using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float inputX;
    float inputY;
    float vel = 1f;
    public Player player;
    public GameObject upperG, DownG;
    // Start is called before the first frame update
    void Start()
    {
        player = new Player();
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement for the player
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(inputX, inputY, 0);
        movement *= Time.deltaTime / vel;
        transform.Translate(movement);

        gameObject.GetComponent<Animator>().SetFloat("Direction", inputY);
    }


    private void OnCollisionEnter2D(Collision2D Collider)
    {
        
        GameObject temp = Collider.gameObject;
        temp.GetComponent<ItemControl>().resetPosition();
        temp.GetComponent<BoxCollider2D>().isTrigger = true;
        Item item = temp.GetComponent<ItemControl>().getItem();
        if(item.GetCloth().getModel() == 1 || item.GetCloth().getModel() == 2)
        {
            upperG.GetComponent<SpriteRenderer>().sprite = item.GetCloth().getFront();
        }
        else
        {
            DownG.GetComponent<SpriteRenderer>().sprite = item.GetCloth().getFront();
        }
        
    }

}
