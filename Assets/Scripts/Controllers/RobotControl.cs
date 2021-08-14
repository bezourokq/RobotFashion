using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControl : MonoBehaviour
{
    float inputX;
    float inputY;
    float vel = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
