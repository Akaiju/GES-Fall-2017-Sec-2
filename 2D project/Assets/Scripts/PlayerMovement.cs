using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float speed = 0.2f;

    private Rigidbody2D myRigidbody2D;

    private bool isOnGround;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        
    }

    [SerializeField]
    private float jumpHeight = 6;
	// Use this for initialization
	void Start ()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        //Debug.Log("Guten morgen. This is in start, lmao.");

        //transform.position = new Vector3(0, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
       
        float horizontalInput = Input.GetAxis("Horizontal");

        Debug.Log("Horizontal input: " + horizontalInput);

        

        //Refactoring to use physics model
        //transform.Translate(speed * horizontalInput, 0, 0);

        myRigidbody2D.velocity =
            new Vector2(speed * horizontalInput, myRigidbody2D.velocity.y);

        
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            myRigidbody2D.velocity =
                new Vector2(myRigidbody2D.velocity.x, jumpHeight);
            isOnGround = false;
        }
    }
}
