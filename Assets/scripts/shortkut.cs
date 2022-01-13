using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shortkut : MonoBehaviour
{
    private int firstlevel = 2;
    private int levelworldscene = 1;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(firstlevel);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(levelworldscene);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Application.Quit();
        }
        
    }
}
