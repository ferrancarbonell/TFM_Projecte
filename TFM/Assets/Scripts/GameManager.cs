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
    public AudioClip deathAudio;
    private AudioSource audioSource;

    void Start()
    {
        Application.targetFrameRate = 60;
        isPlayerAlive = true;
        respawnManager = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnManager>();
        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(deathAudio);
        
        yield return new WaitForSeconds(3f);
        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
