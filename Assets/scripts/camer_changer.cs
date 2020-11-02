using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camer_changer : MonoBehaviour
{
    public bool topdown_view = false;
    private Vector3 up_position;
    private Vector3 side_position;
    
    void Awake()
    {
       up_position = new Vector3 (20f,0f,-5f);
       side_position = new Vector3 (-8f,0f,-5f);
    }
    void Update()
    {
        if (topdown_view)
        {
           transform.position = up_position;
        }
        if(!topdown_view)
        {
            transform.position = side_position;
        }
    }
}
