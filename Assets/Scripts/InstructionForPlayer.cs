using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionForPlayer : MonoBehaviour
{
    public CanvasGroup prompt1CanvasGroup;
    public CanvasGroup prompt2CanvasGroup;
    public float fadeSpeed = 1f;

    private void Start()
    {
        prompt1CanvasGroup.alpha = 0f; 
        prompt2CanvasGroup.alpha = 0f;
        StartCoroutine(FadeCanvasGroup(prompt1CanvasGroup, prompt1CanvasGroup.alpha, 1)); 
    }

    private void Update()
    {
        if (Input.anyKeyDown) 
        {
            if (prompt1CanvasGroup.alpha == 1)
            {
                StartCoroutine(FadeCanvasGroup(prompt1CanvasGroup, prompt1CanvasGroup.alpha, 0)); 
                StartCoroutine(FadeCanvasGroup(prompt2CanvasGroup, prompt2CanvasGroup.alpha, 1)); 
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) && prompt2CanvasGroup.alpha == 1)
            {
                StartCoroutine(FadeCanvasGroup(prompt2CanvasGroup, prompt2CanvasGroup.alpha, 0)); 
            }
        }
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end)
    {
        float counter = 0f;

        while (counter < fadeSpeed)
        {
            counter += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, counter / fadeSpeed);

            yield return null;
        }
    }
}
