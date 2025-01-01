using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject interactionIndicator;
    [SerializeField] private GameObject generalIndicator;
    [SerializeField] private TextMeshProUGUI generalIndicatorMessage;
    [SerializeField] private TextMeshProUGUI scrollMessageText;
    [SerializeField] private GameObject scrollMessage;
    [SerializeField] private TextMeshProUGUI bookshelfMessageText;
    [SerializeField] private GameObject bookshelfMessage;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private InputManagerSO inputManager;


    private CanvasGroup winCanvas;
    private bool gameisPaused = false;
    private bool gameIsFinished = false;

    #region EventSubscriptions
    private void OnEnable()
    {
        InteractionSystem.onPlayerFoundInteractuable += ShowInteractionIndicator;
        InteractionSystem.onPlayerLostInteractuable += HideInteractionIndicator;
        DoorRotation.doorIsBlocked += ShowDoorBlockedMessage;
        DoorRotation.doorNeedsAKey += ShowNeedAKeyMessage;
        inputManager.OnPause += PauseUnpause;
        Scroll.onScrollInteract += ShowScrollMessage;
        LibraryPuzzle.responseIsCorrect += ShowMessageOnIndicator;
        LibraryPuzzle.responseIsIncorrect += ShowMessageOnIndicator; 
        AnimalPuzzle.responseIsCorrect += ShowMessageOnIndicator;
        AnimalPuzzle.responseIsIncorrect += ShowMessageOnIndicator;
        Bookshelf.onBookshelfllInteract += ShowBookshelfMessage;
        CombinationPuzzle.responseIsCorrectC += ShowMessageOnIndicator;
        CombinationPuzzle.responseIsIncorrectC += ShowMessageOnIndicator;
        EndLevelTrigger.onEndLevel += ShowGameWinScreen;
    }

    private void OnDestroy()
    {
        InteractionSystem.onPlayerFoundInteractuable -= ShowInteractionIndicator;
        InteractionSystem.onPlayerLostInteractuable -= HideInteractionIndicator;
        DoorRotation.doorIsBlocked -= ShowDoorBlockedMessage;
        DoorRotation.doorNeedsAKey -= ShowNeedAKeyMessage;
        inputManager.OnPause -= PauseUnpause;
        Scroll.onScrollInteract -= ShowScrollMessage;
        LibraryPuzzle.responseIsCorrect -= ShowMessageOnIndicator;
        LibraryPuzzle.responseIsIncorrect -= ShowMessageOnIndicator;
        AnimalPuzzle.responseIsCorrect -= ShowMessageOnIndicator;
        AnimalPuzzle.responseIsIncorrect -= ShowMessageOnIndicator;
        Bookshelf.onBookshelfllInteract -= ShowBookshelfMessage;
        CombinationPuzzle.responseIsCorrectC -= ShowMessageOnIndicator;
        CombinationPuzzle.responseIsIncorrectC -= ShowMessageOnIndicator;
        EndLevelTrigger.onEndLevel -= ShowGameWinScreen;
    }
    #endregion
    private void Start()
    {
        winCanvas = winScreen.GetComponent<CanvasGroup>();
    }

    private void ShowInteractionIndicator()
    {
        interactionIndicator.SetActive(true);
    }

    private void HideInteractionIndicator()
    {
        interactionIndicator.SetActive(false);
    }

    private void ShowNeedAKeyMessage(string type)
    {
        generalIndicator.SetActive(true);
        generalIndicatorMessage.text = "Necesito la llave " + type + "..." ;
        Invoke(nameof(HideDoorMessageIndicator), 1f);
    }

    private void ShowDoorBlockedMessage(string type)
    {
        generalIndicator.SetActive(true);
        generalIndicatorMessage.text = "Está bloqueada";
        Invoke(nameof(HideDoorMessageIndicator), 1f);
    }

    private void ShowMessageOnIndicator(string message)
    {
        generalIndicator.SetActive(true);
        generalIndicatorMessage.text = message;
        Invoke(nameof(HideDoorMessageIndicator), 2f);
    }

    private void HideDoorMessageIndicator()
    {
        generalIndicator.SetActive(false);
        generalIndicatorMessage.text = "";
    }

    private void ShowGameWinScreen()
    {
        gameIsFinished = true;
        winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(FadeIn(winCanvas));
    }

    private IEnumerator FadeIn(CanvasGroup canvas)
    {
        while (canvas.alpha < 1.0f)
        {
            canvas.alpha += Time.deltaTime / 2;
            yield return null;
        }
    }

    public void PauseUnpause()
    {
        if(!gameIsFinished)
        {
            if (!gameisPaused)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                gameisPaused = true;
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                gameisPaused = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void ShowScrollMessage(string message)
    {
        Time.timeScale = 0f;
        scrollMessageText.text = message;
        scrollMessage.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseScrollMessage()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        scrollMessage.SetActive(false);
    }

    private void ShowBookshelfMessage(string message)
    {
        Time.timeScale = 0f;
        bookshelfMessageText.text = message;
        bookshelfMessage.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseBookshelfMessage()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        bookshelfMessage.SetActive(false);
    }
}
