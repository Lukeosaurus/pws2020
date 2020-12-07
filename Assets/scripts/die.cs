using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class die : MonoBehaviour
{
    private int thisscene;
    private bool ghost_die;
    private bool timer;
    private float timer_count;
    void Start()
    {
        thisscene = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        if (timer)
        {
            if(timer_count > 0.1)
            {
                ghost_die = true;
            }
            else
            {
                timer_count += Time.deltaTime;
            }
        }
        if(!timer)
        {
            timer_count = 0;
        }
        if(ghost_die)
        {
            SceneManager.LoadScene(thisscene);
        }
    }
    

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            SceneManager.LoadScene(thisscene);
            Debug.Log("yes");
        }
        if(collision.gameObject.tag == "bull")
        {
            SceneManager.LoadScene(thisscene);
            Debug.Log("yes");
        }
        if (collision.gameObject.tag == "ghost")
        {
            timer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ghost")
        {
            timer = false;
        }
    }
}
