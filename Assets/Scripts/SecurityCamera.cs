using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecurityCamera : MonoBehaviour
{

    public Light2D spotLight;
    public float viewDistance;
    public LayerMask viewMask;
    private float viewAngle;
    private Transform player;
    private Color originalColor;

    [Header("SpotPlayer")]
    public float timeToSpot;
    private float playerVisibleTimer;

    [Header("End Game")]
    public GameObject endTextUI; 
    public float panelFade = 4.0f;
    public Image gameoverPanel;
    private void Start()
    {
        viewAngle = spotLight.pointLightOuterAngle;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        originalColor = spotLight.color;

    }

    private void Update()
    {
        playerVisibleTimer = Mathf.Clamp(playerVisibleTimer,0, timeToSpot);

        spotLight.color = Color.Lerp(originalColor,Color.red, playerVisibleTimer / timeToSpot);

        if (CanSeePlayer())
        {
            spotLight.color = Color.Lerp(originalColor, Color.red, playerVisibleTimer / timeToSpot);
            playerVisibleTimer += Time.deltaTime;

        }
        else
        {
            spotLight.color = Color.Lerp(originalColor, Color.red, playerVisibleTimer / timeToSpot);
            playerVisibleTimer -= Time.deltaTime;
        }

        if(playerVisibleTimer >= timeToSpot)
        {
            EndGame();

        }
    }

    bool CanSeePlayer()
    {
        if(Vector2.Distance(transform.position, player.position) < viewDistance)
        {
            Vector2 dirToPlayer = (player.position - transform.position).normalized;
            float angleBetweenCameraAndPlayer = Vector2.Angle(transform.right,dirToPlayer);
            Debug.Log(angleBetweenCameraAndPlayer);
            if(angleBetweenCameraAndPlayer < viewAngle / 2f)
            {
                if(!Physics2D.Linecast(transform.position, player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * viewDistance);
    }

    void EndGame()
    {
        StartCoroutine(EndSequence());
    }
    IEnumerator EndSequence()
    {
        if (endTextUI != null)
            endTextUI.SetActive(true);


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
