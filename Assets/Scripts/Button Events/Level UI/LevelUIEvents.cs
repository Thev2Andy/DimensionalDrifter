using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIEvents : MonoBehaviour
{
    public void NextScene(int Scene)
    {
        if(Scene < 0) {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
            return;
        }

        SceneManager.LoadScene((Scene));
    }
}
