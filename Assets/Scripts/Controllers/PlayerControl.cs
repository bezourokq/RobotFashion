using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float inputX;
    float inputY;
    float lastY;
    float vel = 1f;
    public GameObject upperG, downG;
    public Sprite upperSide1, upperSide2, downSide1, downSide2;
    public GameObject inventory;
    bool showInventory;
    // Start is called before the first frame update
    void Start()
    {
        showInventory = false;
        inventory.SetActive(false);
        lastY = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            showInventory = !showInventory;
            inventory.SetActive(showInventory);
        }

        //basic movement for the player
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(inputX, inputY, 0);
        movement *= Time.deltaTime / vel;
        transform.Translate(movement);
        ChangeSideCloth(inputY);
        lastY = inputY;
        gameObject.GetComponent<Animator>().SetFloat("Direction", inputY);
    }

    void ChangeSideCloth(float y)
    {
        if (y > 0)
        {
            
           upperG.GetComponent<SpriteRenderer>().sprite = upperSide1;
           downG.GetComponent<SpriteRenderer>().sprite = downSide1;
        }
        else if(y <0 ){

        }
        upperG.GetComponent<SpriteRenderer>().sprite = upperSide2;
        downG.GetComponent<SpriteRenderer>().sprite = downSide2;
    }
    
    private void OnCollisionEnter2D(Collision2D Collider)
    {
        GameObject temp = Collider.gameObject;
        if (temp.name.Contains("bought"))
        {
            
            temp.GetComponent<ItemControl>().resetPosition();
            temp.GetComponent<BoxCollider2D>().isTrigger = true;
            Item item = temp.GetComponent<ItemControl>().getItem();
            if (item.getCloth().getModel() == 1 || item.getCloth().getModel() == 2)
            {
                //upperG.GetComponent<SpriteRenderer>().sprite = item.GetCloth().getFront();
                upperSide1 = item.getCloth().getFront();
                upperSide2 = item.getCloth().getBack();
                
            }
            else
            {

                //downG.GetComponent<SpriteRenderer>().sprite = item.GetCloth().getFront();
                downSide1 = item.getCloth().getFront();
                downSide2 = item.getCloth().getBack();
            }
            ChangeSideCloth(lastY);
        }       
    }

}
