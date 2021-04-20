using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject blackFader;
    public bool isPlayerAlive;

    void Start()
    {
        Application.targetFrameRate = 60;
        isPlayerAlive = true;
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        StartCoroutine ("StartGameOver");
    }

    IEnumerator StartGameOver()
    {
        isPlayerAlive = false;
        blackFader.GetComponent<Fade>().FadeOut();
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController3D>().PlayerDeath();
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController3D>().enabled = false;
        Debug.Log ("Player death");
        
        yield return new WaitForSeconds(3f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
