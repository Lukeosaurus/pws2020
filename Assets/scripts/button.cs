using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public bool pressed;
    private bool onbutton;
    public SpriteRenderer mySpriteRenderer;
    public Sprite green;
    public Sprite red;
    void Update()
    {
        if(onbutton)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(pressed)
                {
                    pressed = false;
                    mySpriteRenderer.sprite = red; 
                }
                else if(!pressed)
                {
                    mySpriteRenderer.sprite = green; 
                    pressed = true;
                }
            }
        }
    }
    
       
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            onbutton = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            onbutton = false;
        }
    }
}
