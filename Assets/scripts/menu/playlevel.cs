using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playlevel : MonoBehaviour
{
    public int loadlevel;
    
    void Start()
    {
        loadlevel += 1;
    }
    public void go_to_levels()
    {
        SceneManager.LoadScene(loadlevel);
    }
}
