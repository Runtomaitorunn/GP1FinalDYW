using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PondDoorDialogue : MonoBehaviour
{
    public GameObject keyE;
    public Dialogue dialogueManager;

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
            dialogueManager.PrintSentencesPondDoor();

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("player iss here");
        if (other.CompareTag("Player"))
        {
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
