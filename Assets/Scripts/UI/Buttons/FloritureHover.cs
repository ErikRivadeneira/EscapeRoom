using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class FloritureHover : MonoBehaviour
{
    [SerializeField] private GameObject floritureSprite;
    [SerializeField] private bool useSFX;
    [SerializeField] private AudioSource btnSource;
    [SerializeField] private AudioClip hoverEnterSFX;
    [SerializeField] private AudioClip hoverExitSFX;

    public void HoverEnter()
    {
        floritureSprite.SetActive(true);
        if(useSFX)
        {
            btnSource.PlayOneShot(hoverEnterSFX);
        }
    }

    public void ExitHover()
    {
        floritureSprite.SetActive(false);
        if (useSFX)
        {
            btnSource.PlayOneShot(hoverExitSFX);
        }
    }
}
