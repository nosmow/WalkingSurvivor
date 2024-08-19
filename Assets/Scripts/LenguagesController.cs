using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LenguagesController : MonoBehaviour
{
    private bool isActive = false;

    private void Start()
    {
        int id = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLocale(id);
    }

    public void ChangeLocale(int id)
    {
        if (isActive)
        {
            return;
        }
        StartCoroutine(SetLocale(id));
    }

    private IEnumerator SetLocale(int id)
    {
        isActive = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
        PlayerPrefs.SetInt("LocaleKey", id);
        isActive = false;
    }
}
