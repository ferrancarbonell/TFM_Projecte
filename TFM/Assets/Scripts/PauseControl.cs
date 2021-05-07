using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenu;
    public GameObject pauseFirstButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame ()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }
        else 
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void Continue ()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gameIsPaused = false;
    }
    public void MainMenu ()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
        //GameObject.FindWithTag("music").SetActive(false);

    }
}
