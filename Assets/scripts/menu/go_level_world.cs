using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_level_world : MonoBehaviour
{
    private int levelworldscene = 1;
    

    public void go_to_levels()
    {
        SceneManager.LoadScene(levelworldscene);
    }
}
