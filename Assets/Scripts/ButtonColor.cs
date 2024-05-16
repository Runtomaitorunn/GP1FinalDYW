using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems; 

public class ButtonColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText; 
    public Color normalColor;
    public Color hoverColor; 


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = hoverColor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColor; 
    }
}
