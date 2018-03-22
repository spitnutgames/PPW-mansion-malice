using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void NewGameBin(string newGamelevel)
    {
        SceneManager.LoadScene(newGamelevel);

    }

    public void Quit()
    {
        Application.Quit();

    }
}
