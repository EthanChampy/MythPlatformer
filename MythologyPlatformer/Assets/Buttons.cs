using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void newgame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void mainlevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void bosslevel()
    {
        SceneManager.LoadScene("BossLevel");
    }
}
