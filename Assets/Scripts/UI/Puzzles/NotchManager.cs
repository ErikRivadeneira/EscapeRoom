using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotchManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI notchText;
    [SerializeField] private List<string> sides = new List<string>();
    private int currentIndex = 0;
    private string currentSide;

    private void Start()
    {
        notchText.text = sides[currentIndex];
        currentSide = sides[currentIndex];
    }

    public void SetNextSide()
    {
        if(sides.Count-1 == currentIndex)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex++;
        }
        notchText.text = sides[currentIndex];
        currentSide = sides[currentIndex];
    }

    public void SetPreviousSide()
    {
        if (currentIndex == 0)
        {
            currentIndex = sides.Count-1;
        }
        else
        {
            currentIndex--;
        }
        notchText.text = sides[currentIndex];
        currentSide = sides[currentIndex];
    }

    public string GetNotchString()
    {
        return currentSide;
    }
}
