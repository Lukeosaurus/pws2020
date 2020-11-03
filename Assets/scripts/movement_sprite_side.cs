using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_sprite_side : MonoBehaviour
{
    [SerializeField] private LayerMask platformlayermask;
    public float speed;
    public Rigidbody2D rb2d;
    public float big_jump; 
    private Vector2 jumpmove;
    public SpriteRenderer mySpriteRenderer;
    private BoxCollider2D boxCollider2d;
    public float moveHorizontal;
    private bool in_door;
    public float deurnr;
    public bool holding_item = false;
    void Awake()
    {
    boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveHorizontal * speed,rb2d.velocity.y);
    }
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown("space"))
        {
            jumpmove = new Vector2(0f,big_jump);
            rb2d.AddForce (jumpmove);
        }
        moveHorizontal = Input.GetAxis ("Horizontal");
        if (moveHorizontal < 0 )
        {
            mySpriteRenderer.flipX = true;
        }
        if (moveHorizontal > 0 )
        {
            mySpriteRenderer.flipX = false;
        }
        if (in_door)
        {
            if (Input.GetMouseButtonDown(0))
            {
            GameObject other = GameObject.Find("up_test_sprite");
            other.GetComponent<movement_sprite_up>().enabled = true;

            GameObject up_door = GameObject.Find("up deur");
            GameObject up_door1 = GameObject.Find("up deur (1)");
            if (deurnr == 0)
            {
                other.transform.position = up_door.transform.position;
            } 
            if (deurnr ==1)
            {
                other.transform.position = up_door1.transform.position; 
            }

            GameObject Camera = GameObject.Find("Main Camera");
            camer_changer camerachanger = Camera.GetComponent<camer_changer>();
            camerachanger.topdown_view = true;

            GameObject my = GameObject.Find("test_sprite");
            // hier wordt dit script gestopt allles wat belanrijk is moet hiervoor gebeuren 
            my.GetComponent<movement_sprite_side>().enabled = false;
            }
        }
    } 
    private bool IsGrounded()
    {
        float extraHeight = 0.1f; 
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, boxCollider2d.bounds.extents.y + extraHeight, platformlayermask);
        return raycastHit.collider != null; 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "door")
        {
            if (collision.gameObject.name == "side deur")
            {
                deurnr = 0f;
            }
            if (collision.gameObject.name == "side deur (1)")
            {
                deurnr = 1f;
            }
            in_door = true;
        }
        if (collision.gameObject.tag =="ghost")
        {
            Debug.Log("dead");
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
