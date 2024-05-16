using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoticeBoardDialogue : MonoBehaviour
{
    public GameObject keyE;
    public Dialogue dialogueManager;
    private GameObject player;

    private bool isPlayerInRange = false;
    public bool isDialogueActive = false;

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
                        dialogueManager.PrintSentecesNoticeBoard2();

                    }
                    else
                    {
                        dialogueManager.PrintSentecesNoticeBoard1();
                    }
                }


            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            isPlayerInRange = true;
            isDialogueActive = false;
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
        }
    }
}
