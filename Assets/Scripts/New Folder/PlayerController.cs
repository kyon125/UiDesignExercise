using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController :MonoBehaviour
{
    public float addSpeed, maxSpeed , addJumpCoefficient, addJumpSpeed, maxJumpSpeed, maxJumpTime;
    protected Rigidbody2D rb;
    public void Intialstatus()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    public abstract void Move();
    public abstract void Run();
    public abstract void Jump();
    public abstract void FaceDirection();
}
