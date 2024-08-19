using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoaNewScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
