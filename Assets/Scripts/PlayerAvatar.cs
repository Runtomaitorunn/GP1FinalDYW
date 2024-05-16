using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    private Vector2 moveVelocity;
    [Range(0,10)]
    private float speed =1f;
    public float sprintSpeed;
    public float normalSpeed;
    public float sprintTimer;
    public float sprintTime = 2f;   
    public float coolOffTimer;
    public float coolOffTime = 3f;
    [Range(0,5)]
    public float torque;
    public bool abilityToSprint = true;


    private Animator animator;



    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // when shift i down uve to increase velocity
        moveVelocity = moveInput.normalized * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
            
        }
        else
        {
            sprintTimer = 0;
            NotSprint();
        }
        

        if (sprintTimer >= sprintTime)
        {
            CoolOff();
            sprintTimer = 0;
        }

        if(moveInput != Vector2.zero)
        {
            animator.SetBool("isWalking", true);

            if(speed == sprintSpeed)
            {
                animator.SetBool("isSprinting", true);
            }
            else
            {
                animator.SetBool("isSprinting", false);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position+moveVelocity* Time.deltaTime);
        if (moveVelocity.x > 0)
        {
            // Moving right - ensure sprite is facing right direction
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveVelocity.x < 0)
        {
            // Moving left - flip sprite to face left direction
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void Sprint()
    {
        if (abilityToSprint && coolOffTimer==0)
        {
            sprintTimer += Time.deltaTime;
        
            SprintMultiplier();           

        }
        else
        {
            NotSprint();
        }

    }
    public void NotSprint()
    {
        SprintDemultiplier();
        
    }
    public void SprintMultiplier()
    {
        speed =  sprintSpeed;
    }
    public void SprintDemultiplier()
    {
        speed =  normalSpeed;
    }

    public void CoolOff()
    {
        coolOffTimer = 0;
        StartCoroutine(CooloffTimer());
        abilityToSprint = false;
        NotSprint();
    }

    IEnumerator CooloffTimer()
    {
        yield return new WaitForSeconds(1);
        coolOffTimer = coolOffTimer + 1;
        if (coolOffTimer < coolOffTime  && !abilityToSprint)
        {
            StartCoroutine(CooloffTimer());
        }
        if (coolOffTimer >= coolOffTime)
        {
            
            coolOffTimer = 0;
            abilityToSprint=true;
        }
    }

}
