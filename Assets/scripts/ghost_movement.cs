using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_movement : MonoBehaviour
{
    [SerializeField] private LayerMask platformlayermask;
    public Rigidbody2D rb2d;
    public float ghost_speed;
    private BoxCollider2D boxCollider2d;
    public SpriteRenderer mySpriteRenderer;
    
    // Start is called before the first frame update
    // Update is called once per frame
    void Awake()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        
        if (!on_left_edge())
        {
            ghost_speed = Mathf.Abs(ghost_speed);
            mySpriteRenderer.flipX = false;
        }
        if (!on_right_edge())
        {
            ghost_speed = -Mathf.Abs(ghost_speed);
            mySpriteRenderer.flipX = true;
        }
    }
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(ghost_speed, 0f);
    }
    private float extraHeight = 0.1f;
    private bool on_left_edge()
    {   
        
        RaycastHit2D raycastHit1 = Physics2D.Raycast(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x,0), Vector2.down, boxCollider2d.bounds.extents.y + extraHeight, platformlayermask);
        return raycastHit1.collider != null; 
    }
    private bool on_right_edge()
    {   
        
        RaycastHit2D raycastHit2 = Physics2D.Raycast(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x,0), Vector2.down, boxCollider2d.bounds.extents.y + extraHeight, platformlayermask);
        return raycastHit2.collider != null;
    }

}
