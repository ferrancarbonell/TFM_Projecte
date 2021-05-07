using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{   public GameObject startFirstButton;
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(startFirstButton);
    }
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
