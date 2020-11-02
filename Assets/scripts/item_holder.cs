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

    void Update()
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
}
