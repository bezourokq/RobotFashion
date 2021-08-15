using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    float inputX;
    float inputY;
    string lastKey;
    float vel = 1f;
    public GameObject upperG, downG;
    public Sprite upperSide1, upperSide2, downSide1, downSide2;
    public GameObject inventory;
    bool showInventory;
    int money = 100;
    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        showInventory = false;
        inventory.SetActive(false);
        lastKey = "w";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            showInventory = !showInventory;
            inventory.SetActive(showInventory);
        }
        else if (Input.GetKeyDown("s"))
            lastKey = "w";
        else if (Input.GetKeyDown("w"))
            lastKey = "s";
        

        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(inputX, inputY, 0);
        movement *= Time.deltaTime / vel;
        transform.Translate(movement);
        updateCloth();
        gameObject.GetComponent<Animator>().SetFloat("Direction", inputY);
    }

    void updateCloth()
    {
        if(lastKey == "w")
        {
            upperG.GetComponent<SpriteRenderer>().sprite = upperSide1;
            downG.GetComponent<SpriteRenderer>().sprite = downSide1;
        }
        else
        {
            upperG.GetComponent<SpriteRenderer>().sprite = upperSide2;
            downG.GetComponent<SpriteRenderer>().sprite = downSide2;
        }
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
            updateCloth();
        }       
    }

    public void setMoney(int transaction)
    {
        money = money + transaction;
        text.text = money.ToString();
    }

}
