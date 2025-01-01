using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPuzzle : MonoBehaviour
{
    [SerializeField] private string currentOrder;
    [SerializeField] private string correctOrder;
    [SerializeField] private GameObject keyToShow;

    private int paintingCount;
    public delegate void OnPuzzleFinished();
    public static OnPuzzleFinished puzzleIsIncorrect;

    public void OnEnable()
    {
        Painting.onPaintingInteract += AddOrderNumber;
    }
    public void OnDestroy()
    {
        Painting.onPaintingInteract -= AddOrderNumber;
    }

    private void AddOrderNumber(int order)
    {
        paintingCount++;
        currentOrder += order.ToString();
        if(paintingCount == 5)
        {
            if(currentOrder == correctOrder)
            {
                keyToShow.SetActive(true);
            }
            else
            {
                paintingCount = 0;
                currentOrder = "";
                StartCoroutine(ResetPuzzle());
            }
        }
    }

    private IEnumerator ResetPuzzle()
    {
        yield return new WaitForSeconds(1f);
        puzzleIsIncorrect?.Invoke();
    }
}
