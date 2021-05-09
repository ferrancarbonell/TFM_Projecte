using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject blackFader;
    public bool isPlayerAlive;
    private RespawnManager respawnManager;
    public GameObject flema;

    void Start()
    {
        Application.targetFrameRate = 60;
        isPlayerAlive = true;
        respawnManager = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnManager>();
        flema.transform.position = respawnManager.lastCheckpointPos;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void GameOver()
    {
        StartCoroutine ("StartGameOver");
    }

    IEnumerator StartGameOver()
    {
        isPlayerAlive = false;
        blackFader.GetComponent<Fade>().FadeOut();
        Debug.Log ("Player death");
        
        yield return new WaitForSeconds(3f);
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
