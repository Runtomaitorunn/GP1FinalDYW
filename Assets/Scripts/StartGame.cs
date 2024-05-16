using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private CanvasGroup UIGroup;
    [SerializeField] private bool fadeOut = false;
    private string startSceneName = "Main";


    private void Update()
    {
        if (fadeOut)
        {
            if (UIGroup.alpha > 0)
            {
                UIGroup.alpha -= Time.deltaTime;
                if (UIGroup.alpha ==0)
                {
                    fadeOut = false;
                    SceneManager.LoadScene(startSceneName);
                }
            }
        }
    }
    public void PlayGame()
    {
        fadeOut = true;
        

    }


    public void ShowCollection()
    {

    }
}
