using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public string[] sentencesTree;
    public string[] sentencesGlasses;
    public string[] sentencesPondDoor;
    public string[] sentencesNoticeBoard1;
    public string[] sentencesNoticeBoard2;
    public string[] sentencesSnake1;
    public string[] sentencesSnake2;
    public string[] sentencesZooDoor;

    public int index = 0;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject panel;
    public Animator textDisplayAnim;
    private AudioSource textAudioSource;


    private void Start()
    {
        textAudioSource = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if(sentences != null && index >= 0 && index < sentences.Length)
        {
            if (textDisplay.text == sentences[index])
            {

                continueButton.SetActive(true);
            }
            else
            {
            }
        }

    }
    IEnumerator Type(int index)
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }

    }

    public void NextSentence()
    {
        textAudioSource.Play();
        textDisplayAnim.SetTrigger("Change");
        continueButton.SetActive(false);
        if (index < sentences.Length -1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type(index));
            
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            panel.SetActive(false);
        }
    }

    public void PrintSentencesTree()
    {
        sentences = sentencesTree;
        index = 0;
        textDisplayAnim.SetTrigger("Change");
        StartCoroutine(Type(index));
        panel.SetActive(true);
    }

    public void PrintSentencesGlasses()
    {
        sentences = sentencesGlasses;
        index = 0;
        textDisplayAnim.SetTrigger("Change");
        StartCoroutine(Type(index));
        panel.SetActive(true);
    }
    public void PrintSentencesPondDoor()
    {
        sentences = sentencesPondDoor;
        index = 0;
        textDisplayAnim.SetTrigger("Change");
        StartCoroutine(Type(index));
        panel.SetActive(true);
    }

    public void PrintSentecesNoticeBoard1()
    {
        sentences = sentencesNoticeBoard1;
        index = 0;
        textDisplayAnim.SetTrigger("Change");
        StartCoroutine(Type(index));
        panel.SetActive(true);
    }
    public void PrintSentecesNoticeBoard2()
    {
        sentences = sentencesNoticeBoard2;
        index = 0;
        textDisplayAnim.SetTrigger("Change");
        StartCoroutine(Type(index));
        panel.SetActive(true);
    }

    public void PrintSentencesSnake1()
    {
        sentences = sentencesSnake1;
        index = 0;
        textDisplayAnim.SetTrigger("Change");
        StartCoroutine(Type(index));
        panel.SetActive(true);
    }
    public void PrintSentencesSnake2()
    {
        sentences = sentencesSnake2;
        index = 0;
        textDisplayAnim.SetTrigger("Change");
        StartCoroutine(Type(index));
        panel.SetActive(true);
    }

    public void PrintSentencesZooDoor()
    {
        sentences = sentencesZooDoor;
        index = 0;
        textDisplayAnim.SetTrigger("Change");
        StartCoroutine(Type(index));
        panel.SetActive(true);
    }
 
}
