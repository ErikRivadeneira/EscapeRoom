using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    [SerializeField] private string currentResponse;
    [SerializeField] List<NotchManager> notches;

    public delegate void OnCheckAnswer(string answer);
    public static OnCheckAnswer onCheckAnswer;

    public void SendCheckAnswer()
    {
        currentResponse = "";
        foreach (var notch in notches) 
        {
            currentResponse += notch.GetNotchString();
        }
        onCheckAnswer(currentResponse);
    }

    public void ExitPuzzleUI()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        this.gameObject.SetActive(false);
    }
}
