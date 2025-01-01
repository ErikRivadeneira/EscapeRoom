using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalPuzzle : MonoBehaviour, IInteract
{
    [SerializeField] private string correctResponse;
    [SerializeField] private GameObject keyToShow;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private GameObject combinationUI;
    [SerializeField] private string correctMessage;
    [SerializeField] private string incorrectMessage;

    public delegate void OnCheckResponse(string message);
    public static OnCheckResponse responseIsCorrect;
    public static OnCheckResponse responseIsIncorrect;

    private void OnEnable()
    {
        AnimalManager.onCheckAnswer += CheckResponse;
    }
    private void OnDestroy()
    {
        AnimalManager.onCheckAnswer -= CheckResponse;
    }
    private void Start()
    {
        if( particles != null)
        {
            particles.Stop();
        }
    }

    public void CheckResponse(string response)
    {
        if(response == correctResponse)
        {
            this.gameObject.SetActive(false);
            responseIsCorrect?.Invoke(correctMessage);
            ShowParticlesAndObjects();
            HideUI();
            Destroy(this.gameObject, 2);
        }
        else
        {
            responseIsIncorrect?.Invoke(incorrectMessage);
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
        if (keyToShow != null)
        {
            keyToShow?.SetActive(true);
        }
        if (particles != null)
        {
            particles.gameObject.SetActive(true);
            particles.Play();
        }
    }

    public void ExecuteInteract(InteractionSystem player)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        combinationUI.SetActive(true);
    }
}
