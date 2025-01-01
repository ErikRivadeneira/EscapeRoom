using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class UIOptions : MonoBehaviour
{
    [SerializeField] private GameObject parentMenu;
    [SerializeField] private GameObject optionsMenu;

    public void OpenOptions()
    {
        parentMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        parentMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void SetNewLocale(int lngIndex)
    {
        switch (lngIndex)
        {
            case 0:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
                break;
            case 1:
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
                break;
            default: break;
        }
    }
}
