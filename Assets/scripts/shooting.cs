using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    [SerializeField] private LayerMask platformlayermask;
    private BoxCollider2D boxCollider2d;
    public Rigidbody2D rb2d;
    public SpriteRenderer mySpriteRenderer;
    public GameObject wapon;
    private SpriteRenderer wapon_renderer;
    public GameObject ammo;
    private SpriteRenderer ammo_renderer;
    private float shot_timer = 0f;
    
    // Start is called before the first frame update
    void Awake()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        wapon_renderer = wapon.GetComponent<SpriteRenderer>();
        ammo_renderer = ammo.GetComponent<SpriteRenderer>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (player_on_level_left())
        {
                mySpriteRenderer.flipX = false;
                wapon_renderer.flipX = false;
                ammo_renderer.flipX = false;
                if (shot_timer > 3)
                {
                    ammo.SetActive(true);
                    ammo.GetComponent<arrow>().left = false;
                }
                else
                {
                    shot_timer += Time.deltaTime;
                }                
        }
        if (player_on_level_right())
        {
                mySpriteRenderer.flipX = true;
                wapon_renderer.flipX = true;   
                ammo_renderer.flipX = true; 
                if (shot_timer > 3)
                {
                    ammo.SetActive(true);
                    ammo.GetComponent<arrow>().left = true;
                }
                else
                {
                    shot_timer += Time.deltaTime;
                }


        }
        if (!player_on_level_left())
        {
            if (!player_on_level_right())
            {
            shot_timer = 0f;
            }
        }
    }
    private float extra = 5f;
    private bool player_on_level_left()
    {   
        RaycastHit2D raycastHit1 = Physics2D.Raycast(boxCollider2d.bounds.center ,
                Vector2.left, boxCollider2d.bounds.extents.x + extra, platformlayermask);
        return raycastHit1.collider != null; 
    }
    private bool player_on_level_right()
    {   
        RaycastHit2D raycastHit2 = Physics2D.Raycast(boxCollider2d.bounds.center ,
                Vector2.right, boxCollider2d.bounds.extents.x + extra, platformlayermask);
        return raycastHit2.collider != null; 
    }
}
