using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationPuzzle : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject unlockedObject;
    [SerializeField] private GameObject combinationUI;
    [SerializeField] private string correctMessage;
    [SerializeField] private string correctResponse;
    [SerializeField] private string incorrectMessage;

    public delegate void OnCheckResponse(string message);
    public static OnCheckResponse responseIsCorrectC;
    public static OnCheckResponse responseIsIncorrectC;

    private void OnEnable()
    {
        CombinationManager.onCheckAnswer += CheckResponse;
    }
    private void OnDestroy()
    {
        CombinationManager.onCheckAnswer -= CheckResponse;
    }

    public void CheckResponse(string response)
    {
        if(correctResponse.Equals(response))
        {
            ShowParticlesAndObjects();
            HideUI();
            unlockedObject.tag = "Interactuable";
            this.gameObject.tag = "Untagged";
            responseIsCorrectC?.Invoke(correctMessage);
            Destroy(this.gameObject);

        }
        else
        {
            responseIsIncorrectC?.Invoke(incorrectMessage);
        }
    }

    private void HideUI()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        combinationUI.SetActive(false);
    }

    private void ShowParticlesAndObjects()
    {
        if (unlockedObject != null)
        {
            unlockedObject.tag = "Interactuable";
        }
    }

    public void ExecuteInteract(InteractionSystem player)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        combinationUI.SetActive(true);
    }
}
