using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 4;
    //check to see if player is moving or not
    private bool playerMoving;
    //player's last move
    private Vector2 lastMove;

    private Camera mainCamera;

    private Vector3 movementInput;

    //this can be used to transform the weapon character is holding
    public Transform controlThisObject;

    //movementINput
    private Vector3 mousePos;

    private Vector2 mouseVec;
    private float mouseAngle;

    //constructor
    public PlayerMovement()
    {
        mousePos = new Vector3(0f, 0f, 0f);
    }
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mainCamera = FindObjectOfType<Camera>();
    }
    
    void Update()
    {

        Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        float WorldXPos = Camera.main.ScreenToWorldPoint(pos).x;

        
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        
        //Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
    }
    //movement
    void FixedUpdate(){

        //player movement
        //playerMoving = false;
        //if (horizontal != 0 && vertical != 0)
        //{
        //    body.velocity = new Vector3((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter);
        //    playerMoving = true;
        //    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        //}
        //else
        //{
        //    body.velocity = new Vector3(horizontal * runSpeed, vertical * runSpeed);
        //    playerMoving = true;
        //    lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        //}
        //player animator references
        /*
        anim.SetFloat("xInput", horizontal);
        anim.SetFloat("yInput", vertical);

        anim.SetBool("isMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);*/


        body.velocity = movementInput * runSpeed;

        if (movementInput == Vector3.zero)
        {
            playerMoving = false;
            anim.StartPlayback();
        } 
        else
        {
            playerMoving = true;
            anim.StopPlayback();
        }

        Debug.Log(playerMoving);

        UpdateAnimations();
    }

    private void setAnimInput(float x, float y)
    {
        anim.SetFloat("xInput", x);
        anim.SetFloat("yInput", y);
        anim.SetBool("isMoving", playerMoving);
    }

    private void UpdateAnimations()
    {
        mouseVec = Input.mousePosition - mainCamera.WorldToScreenPoint(transform.position);
        mouseAngle = Mathf.Atan2(mouseVec.y, mouseVec.x);

        if (mouseAngle >= 0) // positive
        {
            if (mouseAngle <= (Mathf.PI / 2)) // upper right quadrant
            {
                if (mouseAngle <= (Mathf.PI / 6)) // right
                {

                    setAnimInput(1, 0);
                }
                else
                {
                    if (mouseAngle <= (Mathf.PI / 3)) // up right
                    {
                        setAnimInput(1, 1);
                    }
                    else // up
                    {
                        setAnimInput(0, 1);
                    }
                }
            }
            else // upper left quandrant
            {
                if (mouseAngle >= (5 * Mathf.PI / 6)) // left
                {
                    setAnimInput(-1, 0);
                }
                else
                {
                    if (mouseAngle >= (2 * Mathf.PI / 3)) // up left
                    {
                        setAnimInput(-1, 1);
                    }
                    else // up
                    {
                        setAnimInput(0, 1);
                    }
                }
            }
        }
        else
        {
            if (mouseAngle <= (Mathf.PI / -2))
            {
                if (mouseAngle <= (-5 * Mathf.PI / 6)) // left
                {
                    setAnimInput(-1, 0);
                }
                else
                {
                    if (mouseAngle <= (-2 * Mathf.PI / 3)) // down left
                    {
                        setAnimInput(-1, -1);
                    }
                    else // down
                    {
                        setAnimInput(0, -1);
                    }
                }
            }
            else
            {
                if (mouseAngle >= (Mathf.PI / -6)) // right
                {
                    setAnimInput(1, 0);
                }
                else
                {
                    if (mouseAngle >= (Mathf.PI / -3)) // down right
                    {
                        setAnimInput(1, -1);
                    }
                    else // down\
                    {
                        setAnimInput(0, -1);
                    }
                }
            }
        }
        
    }

    
}
