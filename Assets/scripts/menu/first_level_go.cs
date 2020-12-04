using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class first_level_go : MonoBehaviour
{
    private int levelworldscene = 2;
    

    public void go_to_levels()
    {
        SceneManager.LoadScene(levelworldscene);
    }
}
