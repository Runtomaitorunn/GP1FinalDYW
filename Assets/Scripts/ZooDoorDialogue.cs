using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ZooDoorDialogue : MonoBehaviour
{
    public GameObject keyE;
    public Dialogue dialogueManager;

    private bool isPlayerInRange = false;
    public bool isDialogueActive = false;
    public bool endGame = false;


    public float panelFade = 4.0f;
    public Image gameoverPanel;


    void Start()
    {
        if (keyE != null) keyE.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E) && !isDialogueActive)
        {
            isDialogueActive = true;
            dialogueManager.PrintSentencesZooDoor();
            endGame = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isDialogueActive = false;
            isPlayerInRange = true;
            if (keyE != null) keyE.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            isDialogueActive = false;
            if (keyE != null) keyE.SetActive(false);
            if (endGame)
            {
                StartCoroutine(EndSequence());
            }
        }
    }
    IEnumerator EndSequence()
    {


        float Timer = 0;
        while (Timer <= panelFade)
        {
            gameoverPanel.color = new Color(0, 0, 0, Timer / panelFade);
            Timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(4);


        SceneManager.LoadScene("EndSceneSad");
    }
}
