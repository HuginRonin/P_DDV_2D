using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LanguageButton : MonoBehaviour, IPointerClickHandler
{

    public Language l;

    public void OnPointerClick(PointerEventData eventData)
    {
        Localizator.SetLanguage(l);
    }
}
