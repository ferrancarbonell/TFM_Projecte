using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Configure()
    {
        Debug.Log("Configure");
    }

}
