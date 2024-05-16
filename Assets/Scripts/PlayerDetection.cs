using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{
    public UnityEvent onPlayerCaught;

    private void Start()
    {
        if (onPlayerCaught != null)
        
            onPlayerCaught = new UnityEvent(); 
    }
    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag( "Player"))
        {
            onPlayerCaught.Invoke();
        }

    }
}
