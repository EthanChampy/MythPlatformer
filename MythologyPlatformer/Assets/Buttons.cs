using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void newgame()
    {
        PlayerPrefs.SetInt("Health", 6);
        PlayerPrefs.SetInt("Armor", 0);
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Damage", 1);
        SceneManager.LoadScene("Tutorial");
    }

    public void mainmenu()
    {
        PlayerPrefs.SetInt("Health", 6);
        PlayerPrefs.SetInt("Armor", 0);
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Damage", 1);
        SceneManager.LoadScene("MainMenu");
    }

    public void mainlevel()
    {
        PlayerPrefs.SetInt("Health", 6);
        PlayerPrefs.SetInt("Armor", 0);
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Damage", 1);
        SceneManager.LoadScene("MainLevel");
    }

    public void bosslevel()
    {
        PlayerPrefs.SetInt("Health", 6);
        PlayerPrefs.SetInt("Armor", 0);
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Damage", 1);
        SceneManager.LoadScene("BossLevel");
    }
}
