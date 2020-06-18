using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public Objectives objectives;
    public GameObject player;
    public GameObject EndScreenUI;

    void Update()
    {
        if(objectives.end == true && player.transform.position.x < 60 && player.transform.position.y < 0)
        {
            EndScreenUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
