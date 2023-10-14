using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D myRb; 
    float mvHorizontal,mvVertical;
    public float speed = 2f;
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        mvHorizontal = Input.GetAxisRaw("Horizontal");
        mvVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        myRb.velocity = new Vector2 (mvHorizontal * speed, mvVertical * speed);
    }


}
