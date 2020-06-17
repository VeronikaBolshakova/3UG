using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{


    public GameObject deathScreen;
    public GameObject player;
    public CheckpointSystem checkpointSystem;
    public void StartDeathScreen()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }


   
    public void Retry()
    {

        deathScreen.SetActive(false);
        player.GetComponent<movement>().MaxHealth();
        player.transform.position = checkpointSystem.RestartPlayerPosition();
        Time.timeScale = 1f;

    }

    public void LoadMenu()
    {

        deathScreen.SetActive(false);
        SceneManager.LoadScene("Menu");

    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
