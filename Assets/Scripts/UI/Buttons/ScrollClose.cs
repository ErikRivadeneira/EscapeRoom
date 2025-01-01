using UnityEngine;
using UnityEngine.UI;

public class ScrollClose : MonoBehaviour
{
    [SerializeField] private Image btnImage;
    [SerializeField] private AudioClip hoverEnterSFX;
    [SerializeField] private AudioClip hoverExitSFX;

    public void HoverEnter()
    {
        btnImage.color = new Color(255,255,255,255);
        AudioSource.PlayClipAtPoint(hoverEnterSFX, Vector3.zero);
    }

    public void HoverExit()
    {
        btnImage.color = new Color(255, 255, 255, 0);
        AudioSource.PlayClipAtPoint(hoverEnterSFX, Vector3.zero);
    }
}
