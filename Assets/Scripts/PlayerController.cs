using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator playerAnimator;
    public float JumpForce = 10;
    public float GravityModifier;
    public bool IsOnGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround == true && !gameOver)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }
        if (IsOnGround == false)
        {
            playerAnimator.SetBool("Jump_b", true);
        }
        else
        {
            playerAnimator.SetBool("Jump_b", false);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsOnGround = true;
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnimator.SetInteger("DeathType_int", 1);
            playerAnimator.SetBool("Death_b", true);
        }
    }
}
