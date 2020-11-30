using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class in_range : MonoBehaviour
{
    private BoxCollider2D boxCollider2d;
    public GameObject dad;
    private bool inrange;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inrange = true;
        }
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inrange = false;
        }
    }
    void Update()
    {
        if(inrange)
        {
            dad.GetComponent<bull>().enemy_spoted = true;
        }
        if(!inrange)
        {
            dad.GetComponent<bull>().enemy_spoted = false;
        }
    }
}
