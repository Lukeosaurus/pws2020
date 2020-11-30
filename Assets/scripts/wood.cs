using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    public GameObject my; 
    private BoxCollider2D boxCollider2d;
    public GameObject bull_enemy;
    void Awake()
    {
    boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bull")
        {
            if(bull_enemy.GetComponent<bull>().charge == true)
            {    
                my.SetActive(false);
            }
        }
    }
}
