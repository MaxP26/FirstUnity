using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Animator anim;
    int animId;
    public int AnimId
    {
        get=>animId;
        set
        {
            animId = value;
            anim.SetInteger("animId", value);
        }
    }
    public float jump = 6;
    public float moveSpeed = 4;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float checkRadius;
    public bool IsGrounded=> Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);

    LayerMask WhatIsGround;
    public bool FasingForvard
    {
        get => transform.localScale.x > 0;
        set
        {
            if (FasingForvard != value)
            {
                var scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity=new Vector2 (
            Input.GetAxis("Horizontal") * moveSpeed,
            rb.velocity.y);
    }
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded)
		{
			rb.velocity=new Vector2 (rb.velocity.x, rb.velocity.y+jump);
		}
        playanimation();
	}
	void playanimation()
    {
        float moveX = rb.velocity.x;
        float moveY = rb.velocity.y;
        if (IsGrounded)
        {
            if (moveX == 0)
            {
                anim.SetInteger("animId", 0);
            }
            else
            {
                anim.SetInteger("animId", 1);
                FasingForvard = moveX > 0;
            }
        }
        else if (moveY>0)
        {
            anim.SetInteger("animId", 2);
        }
        else
        {
            anim.SetInteger("animId", 3);
        }
    }
}
