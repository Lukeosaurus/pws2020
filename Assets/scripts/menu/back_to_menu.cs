using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back_to_menu : MonoBehaviour
{
    private int menu = 0;
    
    public void go_to_levels()
    {
        SceneManager.LoadScene(menu);
    }
}
