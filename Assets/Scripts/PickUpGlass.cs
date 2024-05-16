using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGlass : MonoBehaviour
{
    public GameObject keyE;
    private GameObject player;
    public Dialogue dialogueManager;

    private bool isPlayerInRange = false;

    void Start()
    {
        if (keyE != null) keyE.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (keyE != null) keyE.SetActive(false);
            GlassOn();
            dialogueManager.PrintSentencesGlasses();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            isPlayerInRange = true;
            if (keyE != null) keyE.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (keyE != null) keyE.SetActive(false);
        }
    }
    void GlassOn()
    {
        if (player != null)
        {
            Transform glasses = player.transform.Find("Glasses");
            if (glasses != null)
            {
                glasses.gameObject.SetActive(true); 

                
            }

        }
    }
}
