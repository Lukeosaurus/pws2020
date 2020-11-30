using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bull : MonoBehaviour
{   
    public bool base_movement_up;
    public bool base_movement_side;
    public float speed;
    public float charge_speed;
    private float side_speed;
    private float up_speed;
    public Rigidbody2D rb2d;
    [SerializeField] private LayerMask platformlayermask;
    private BoxCollider2D boxCollider2d;
    public Transform target;
    public bool enemy_spoted;
    private float timer = 0;
    private bool charge = false;
    Vector3 old_enemy_direction;
    
    void Awake()
    {
    boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        if(base_movement_up)
        {
            up_speed = speed;
        }
        if(base_movement_side)
        {
            side_speed = speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hits_up())
        {
            up_speed = -speed;
            charge = false;
            enemy_spoted = false;
        }
        if(hits_down())
        {
            up_speed = speed;
            charge = false;
            enemy_spoted = false;
        }
        if(hits_left())
        {
            side_speed = speed;
            charge = false;
            enemy_spoted = false;
        }
        if(hits_right())
        {
            side_speed = -speed;
            charge = false;
            enemy_spoted = false;
        }

    }
    void FixedUpdate()
    {
        if(!enemy_spoted && !charge)
        {
            rb2d.velocity = new Vector2(side_speed,up_speed);
        }
        if(enemy_spoted)
        {
            if(timer<5)
            {
                rb2d.velocity = new Vector2(0,0);
                timer += Time.deltaTime;
            }
            if(timer>=5)
            {
                if(!charge)
                {
                charge = true;
                float step = charge_speed;
                old_enemy_direction =  Vector3.MoveTowards(transform.position, target.position, step) - transform.position;
                }
            }
        }
        if (charge)
        {
            
            transform.position += old_enemy_direction ;
            timer = 0;
            Debug.Log(rb2d.velocity);
            //if(transform.position == old_enemy_pos)
            //{
            //    charge = false;
            //    enemy_spoted = false;
            //}
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "door")
        {
            
        }
    }
    float extraHeight = 0.1f; 
    private bool hits_up()
    {
        RaycastHit2D raycastHit1 = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.up, boxCollider2d.bounds.extents.y , platformlayermask);
        return raycastHit1.collider != null;
    }
    private bool hits_down()
    {
        RaycastHit2D raycastHit2 = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y, platformlayermask);
        return raycastHit2.collider != null;
    }
    private bool hits_left()
    {
        RaycastHit2D raycastHit3 = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.left, boxCollider2d.bounds.extents.x, platformlayermask);
        return raycastHit3.collider != null;
    }
    private bool hits_right()
    {
        RaycastHit2D raycastHit4 = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.right, boxCollider2d.bounds.extents.x, platformlayermask);
        return raycastHit4.collider != null;
    }
}
