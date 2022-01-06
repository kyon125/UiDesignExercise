using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UnityChanController :  PlayerController
{
    // Start is called before the first frame update
    CharaterStatus charater;
    public Ease jumpEase;
    public float jumpTime , jumpLimit ,nowSpeed;
    bool isjumping;
    private void Start()
    {
        charater = CharaterStatus.charater;
        Intialstatus();
    }
    private void Update()
    {
        nowSpeed = rb.velocity.y;
        Jump();
        Move();
    }
    public override void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
        }
        else if (Input.GetButton("Jump") && charater.playerPosStatus == PlayerPosStatus.isGrounded)
        {
            jumpTime += Time.deltaTime;
            charater.playerStatus = PlayerStatus.isJump;
            rb.AddForce(Vector2.up * addJumpSpeed);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            //if (charater.playerPosStatus == PlayerPosStatus.isGrounded)
            //{
            //    if (rb.velocity.y < maxJumpSpeed)
            //    {
            //        rb.AddForce(Vector2.up * addJumpSpeed * jumpTime / maxJumpTime);
            //    }
            //    else
            //        rb.velocity = new Vector2(rb.velocity.x, maxJumpSpeed);
            //}
            isjumping = false;
            jumpTime = 0;
        }            
    }
    public override void FaceDirection()
    {
        float frontvalue = Input.GetAxis("Horizontal");
        if (frontvalue < 0)
        {
            if (Mathf.Abs(rb.velocity.x) < maxSpeed && rb.velocity.x < 0)
                rb.AddForce(-Vector2.right * addSpeed * Time.deltaTime *1000);
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
            }

            transform.localRotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            if (Mathf.Abs(rb.velocity.x) < maxSpeed && rb.velocity.x > 0)
                rb.AddForce(Vector2.right * addSpeed * Time.deltaTime * 1000);
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                rb.velocity = new Vector2(maxSpeed , rb.velocity.y);                
            }

            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public override void Move()
    {
        
        if (Input.GetButton("Horizontal"))
        {
            FaceDirection();
            charater.playerStatus = PlayerStatus.isWalk;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        charater.playerStatus = rb.velocity == new Vector2(0, 0) ? PlayerStatus.isIdel : charater.playerStatus;
    }

    public override void Run()
    {
        
    }
}
