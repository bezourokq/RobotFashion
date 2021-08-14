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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && playerOn)
        {
            showGoods = !showGoods;
            store.SetActive(showGoods);
        }
    }
    private void OnCollisionEnter2D(Collision2D Collider)
    {
        GameObject temp = Collider.gameObject;
        Debug.Log("entrou");
        playerOn = true;
    }
    private void OnCollisionExit2D(Collision2D Collider)
    {
        GameObject temp = Collider.gameObject;
        Debug.Log("saiu");
        playerOn = false;
        showGoods = false;
        store.SetActive(showGoods);

    }
}
