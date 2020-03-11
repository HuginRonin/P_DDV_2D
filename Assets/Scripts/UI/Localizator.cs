using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localizator : MonoBehaviour
{
    public static Localizator Instance;

    public TextAsset DataSheet;

    Dictionary<string, LanguageData> keyData;
    [SerializeField]
    private Language currentLanguage; 
    private Language defaultLanguage = Language.Spanish;

    public delegate void LanguageChangeDelegate();
    public static LanguageChangeDelegate OnLanguageChange;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        Instance = this;
        currentLanguage = defaultLanguage;
        ReadSheet();
    }

    private void ReadSheet()
    {
        string[] lines = DataSheet.text.Split(new char[] { '\n' });
        for(int i = 1; i < lines.Length; i++)
        {
            if (lines.Length > 1)
            {
                AddNewDataEntry(lines[i]);
            }
        }
    }

    private void AddNewDataEntry(string s)
    {
        string[] p = s.Split(new char[] { ',' }); //consultar como está en el archivo
        var languageData = new LanguageData(p);
        if(keyData == null)
        {
            keyData = new Dictionary<string, LanguageData>();
        }

        keyData.Add(p[0], languageData);
    }

    public static string GetText(string textKey)
    {
        return Instance.keyData[textKey].GetText(Instance.currentLanguage);
    }

    public static void SetLanguage(Language l)
    {
        Instance.currentLanguage = l;
        OnLanguageChange?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
