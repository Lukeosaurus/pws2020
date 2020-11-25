using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public bool shoot = false;
    public Vector3 speed;
    public GameObject my_arrow;
    public GameObject holder;
    public bool left;
    private float arrow_timer = 0;
    private bool stop = false;
    bool timerstart = false;
    void OnEnable()
    {
        my_arrow.transform.position = holder.transform.position;
        stop = false;
        timerstart = false;
        arrow_timer = 0f;
    }
    void FixedUpdate()
    {
        if (!stop)
        {
        if (left)
        {
            transform.position += speed;
        }
        if (!left)
        {
            transform.position -= speed;
        }
        }
        if (timerstart)
        {
            if (arrow_timer > 2)
            {
                my_arrow.SetActive(false);
            }
            else 
            {
                arrow_timer += Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tilemap")
        {
            stop = true;
            timerstart = true;
        }
    } 
}
