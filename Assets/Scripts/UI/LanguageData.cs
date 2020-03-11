using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    Spanish = 1,
    Catalan = 2,
    English = 3
}

public class LanguageData
{
    Dictionary<Language, string> Data;

    public LanguageData(string[] rawData)
    {
        Data = new Dictionary<Language, string>();
        for(int i = 1; i < rawData.Length; i++)
        {
            Data.Add((Language)i, rawData[i]);
        }
    }

    public string GetText(Language l)
    {
        return Data[l];
    }
 
}
