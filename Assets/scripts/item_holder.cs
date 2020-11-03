using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_holder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item;
    public GameObject player;
    public SpriteRenderer mySpriteRenderer;
    bool player_fliped = false;
    bool this_in_hand = false;
    bool standing_on_item = false;

    void Update()
    {   
        if (this_in_hand)
        {
        player_fliped = player.GetComponent<SpriteRenderer>().flipX;
        item.transform.position = player.transform.position;
        if(player_fliped)
        {
            mySpriteRenderer.flipX = true;
        }
        if(!player_fliped)
        {
            mySpriteRenderer.flipX = false;
        }
        }
        if (standing_on_item)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {   
                if(this_in_hand)
                {
                    this_in_hand = false;
                    player.GetComponent<movement_sprite_side>().holding_item = false;
                }
                else if(!this_in_hand)
                {
                    if(!player.GetComponent<movement_sprite_side>().holding_item)
                    {
                        this_in_hand = true;
                        player.GetComponent<movement_sprite_side>().holding_item = true;
                    }
                }
            }
        }
       
            
        
       
           
        
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            standing_on_item = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            standing_on_item = false;
        }
    }
}
