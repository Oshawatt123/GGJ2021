using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject options_menu;
    public GameObject menu;
    public GameObject exit_menu;

    public void StartGame()
    {
        
    }
    public void Options()
    {
        Debug.Log("Options menu pressed");
        options_menu.SetActive(true);
        menu.SetActive(false);

    }
    public void doExitGame()
    {
        menu.SetActive(false);
        exit_menu.SetActive(true);
    }
    public void back()
    {
        options_menu.SetActive(false);
        menu.SetActive(true);
    }
    public void backexit()
    {
        exit_menu.SetActive(false);
        menu.SetActive(true);
    }
    public void exit()
    {
        Application.Quit();
    }
}
