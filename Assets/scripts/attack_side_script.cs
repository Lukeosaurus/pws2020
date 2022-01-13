using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_side_script : MonoBehaviour
{
    public bool holding_item;
    public bool fire_abilety;
    public bool attack = false;
    
    void Update()
    {
        if(holding_item)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                attack = true;
            }
            else
            {
                attack = false;
            }
        }
    }
}
