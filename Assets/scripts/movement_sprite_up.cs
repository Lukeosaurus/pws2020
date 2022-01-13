using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_sprite_up : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;
    public float moveHorizontal;
    public float moveVertical;
    private bool in_door; 
    public float deurnr;
    // Update is called once per frame
    
    void Update()
    {
        moveHorizontal = Input.GetAxis ("Horizontal");
        moveVertical = Input.GetAxis ("Vertical");  
        if (in_door)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
            GameObject other = GameObject.Find("test_sprite");
            other.GetComponent<movement_sprite_side>().enabled = true;
            other.GetComponent<die>().enabled = true;

            GameObject side_door = GameObject.Find("side deur");
            GameObject side_door1 = GameObject.Find("side deur (1)");
            if (deurnr == 0)
            {
                other.transform.position = side_door.transform.position;
            } 
            if (deurnr ==1)
            {
                other.transform.position = side_door1.transform.position; 
            }
            

            GameObject Camera = GameObject.Find("Main Camera");
            camer_changer camerachanger = Camera.GetComponent<camer_changer>();
            camerachanger.topdown_view = false;

            GameObject my = GameObject.Find("up_test_sprite");
            // hier wordt dit script gestopt allles wat belanrijk is moet hiervoor gebeuren 
            my.GetComponent<movement_sprite_up>().enabled = false;
            }

        }
    }
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveHorizontal * speed,moveVertical * speed);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "door")
        {
            if (collision.gameObject.name == "up deur")
            {
                deurnr = 0f;
            }
            if (collision.gameObject.name == "up deur (1)")
            {
                deurnr = 1f;
            }
            in_door = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "door")
        {
            in_door = false;
        }
    }
}
