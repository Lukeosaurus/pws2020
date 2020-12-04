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
    public bool hit_ghost = false;
    public bool hit_archer = false;
    public float hp = 50f;
    public bool kill = false;
    public GameObject enemy;
    public GameObject mybutton;
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
            if (mybutton.GetComponent<button>().pressed == true)
            {
                if (Input.GetMouseButtonDown(1))
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
        if (hit_ghost)
        {
            GameObject my = GameObject.Find("test_sprite");
            if (holding_item && Input.GetMouseButtonDown(0))
            {
                if (my.GetComponent<attack_side_script>().fire_abilety == true)
                {
                    kill = true;
                    hp = 50;
                }
                else
                {
                    if (hp>0f)
                    {
                        hp -=1;
                    }
                    if (hp == 0f)
                    {
                        Debug.Log("die");
                    }
                }
            }
            else
            {
                if (hp>0f)
                {
                    hp -=1;
                }
                if (hp == 0f)
                {
                    Debug.Log("die");
                }
                
            }
        }
        if (hit_archer)
        {
            GameObject my = GameObject.Find("test_sprite");
            if (holding_item && Input.GetMouseButtonDown(0))
            {
                if (my.GetComponent<attack_side_script>().fire_abilety == false)
                {
                    kill = true;
                    hp = 50;
                }
                else
                {
                    if (hp>0f)
                    {
                        hp -=1;
                    }
                    if (hp == 0f)
                    {
                        Debug.Log("die");
                    }
                }
            }
            else
            {
                if (hp>0f)
                {
                    hp -=1;
                }
                if (hp == 0f)
                {
                    Debug.Log("die");
                }
                
            }

        }
        if(kill)
        {
            enemy.SetActive(false);
            kill = false;
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
            hit_ghost = true;
            hit_archer = false;
            enemy = GameObject.Find(collision.gameObject.name);
        }
        if (collision.gameObject.tag =="archer")
        {
            hit_archer = true;
            hit_ghost = false;
            enemy = GameObject.Find(collision.gameObject.name);
        }
        else
        {
            hit_ghost = false;
            hit_archer = false;

        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "door")
        {
            in_door = false;
        }
        if (collision.gameObject.tag =="ghost")
        {
            hit_ghost = false;
        }
    }
    
}
