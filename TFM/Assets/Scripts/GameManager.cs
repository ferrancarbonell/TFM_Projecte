using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject blackFadeOut;

    void Start()
    {
        Application.targetFrameRate = 60;
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
        blackFadeOut.SetActive (true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController3D>().PlayerDeath();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController3D>().enabled = false;
        yield return new WaitForSeconds(3f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
