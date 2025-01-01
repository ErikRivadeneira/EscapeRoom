using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour, IInteract
{
    [SerializeField] ParticleSystem paintingParticles;
    [SerializeField] int orderNumber;

    public delegate void OnPaintingInteract(int order);
    public static OnPaintingInteract onPaintingInteract;

    private void OnEnable()
    {
        PaintingPuzzle.puzzleIsIncorrect += HideParticles;
    }

    private void OnDestroy()
    {
        PaintingPuzzle.puzzleIsIncorrect -= HideParticles;
    }

    private void HideParticles()
    {
        this.gameObject.tag = "Interactuable";
        paintingParticles.gameObject.SetActive(false);
        paintingParticles.Stop();
        
    }

    private void ShowParticles()
    {
        paintingParticles.gameObject.SetActive(true);
        paintingParticles.Play();
    }

    public void ExecuteInteract(InteractionSystem player)
    {
        ShowParticles();
        onPaintingInteract?.Invoke(orderNumber);
        this.gameObject.tag = "Untagged";
    }
}
