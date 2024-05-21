using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpener : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject HudUI;
    public GameObject KingUI;
    public GameObject GrandfatherUI;
    public GameObject TavernUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        HudUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        HudUI.SetActive(false);
        KingUI.SetActive(false);
        GrandfatherUI.SetActive(false);
        TavernUI.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LeaveGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true ;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
