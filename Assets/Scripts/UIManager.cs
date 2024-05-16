using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI endText;

    public void ShowEndGameText()
    {
        endText.gameObject.SetActive(true);
    }
}
