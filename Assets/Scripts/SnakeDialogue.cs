using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeDialogue : MonoBehaviour
{
    public GameObject keyE;
    public Dialogue dialogueManager;
    private GameObject player;
    public bool endGame = false;

    private bool isPlayerInRange = false;
    public bool isDialogueActive = false;

    [Header("End Game")]
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
            if (keyE != null) keyE.SetActive(false);
            {
                if (player != null)
                {
                    Transform glasses = player.transform.Find("Glasses");
                    if (glasses != null && glasses.gameObject.activeInHierarchy)
                    {
                        dialogueManager.PrintSentencesSnake2();
                        endGame = true;
                    }
                    else
                    {
                        dialogueManager.PrintSentencesSnake1();
                    }
                }

            }
        }
    }

        void OnTriggerEnter2D (Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                player = other.gameObject;
                isPlayerInRange = true;
                isDialogueActive = false;
            if (keyE != null) keyE.SetActive(true);
            }
        }

        void OnTriggerExit2D (Collider2D other)
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


        SceneManager.LoadScene("EndSceneHappy");
    }
}