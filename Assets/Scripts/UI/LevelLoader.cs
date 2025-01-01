using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private float time;
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    } 

    public void LoadPreviousLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void BackToMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void QuitGame()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play Animation
        transition.SetTrigger("Start");
        // Wait for animation to finish
        yield return new WaitForSeconds(time);
        // LoadScene
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator EndGame()
    {
        // Play Animation
        transition.SetTrigger("Start");
        // Wait for animation to finish
        yield return new WaitForSeconds(time);
        // LoadScene
        Application.Quit();
    }
}
