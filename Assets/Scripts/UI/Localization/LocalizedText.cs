using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizedText : MonoBehaviour
{
    private TextMeshProUGUI text;
    public string TextKey;

    private void OnEnable()
    {
        Localizator.OnLanguageChange += ChangeLanguage;
    }

    private void OnDisable()
    {
        Localizator.OnLanguageChange -= ChangeLanguage;
    }

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        SetText(TextKey);
    }

    private void SetText(string textKey)
    {
        text.text = Localizator.GetText(textKey);
    }

    private void ChangeLanguage()
    {
        SetText(TextKey);
    }
}
