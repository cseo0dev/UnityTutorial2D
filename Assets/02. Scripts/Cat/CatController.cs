﻿using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public float jumpPower = 10f;
    public float limitPower = 9f;

    public bool isGround = false;

    public int jumpCount = 0;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // 2단 점프 구현
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("IsGround", false);

            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;

            soundManager.OnJumpSound();

            // 점프 속도(높이) 제한
            if(catRb.linearVelocityY > limitPower)
                catRb.linearVelocityY = limitPower;
        }

        // 고양이 회전 구현
        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocity.y * 5f;
        transform.eulerAngles = catRotation;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // 점프 중일 때 계속 점프 애니메이션이 작동되도록
            catAnim.SetBool("IsGround", true);

            isGround = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
