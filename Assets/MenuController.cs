using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    void Load()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    void Close()
    {
        Application.Quit();
    }
}
