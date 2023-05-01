using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;

    private Rigidbody rb;
    private Animator playerAnimator;


    public float JumpForce = 10;
    public float GravityModifier;
    public static float score = 0;



    public bool IsOnGround = true;
    public bool gameOver = false;

    private int doubleJumpStatus = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && doubleJumpStatus < 2)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
            doubleJumpStatus++;
        }


        if (IsOnGround == false)
        {
            playerAnimator.SetBool("Jump_b", true);
        }
        else
        {
            playerAnimator.SetBool("Jump_b", false);
        }


        if (Input.GetKey(KeyCode.L) && IsOnGround &&!gameOver)
        {
            Time.timeScale = 1.5f;
            score = score + Time.deltaTime + 0.5f;
            Debug.Log("YOUR SCORE: " + score);
        }
        else
        {
            Time.timeScale = 1;
        }
    }







    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsOnGround = true;
            dirtParticle.Play();
            doubleJumpStatus = 0;
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnimator.SetInteger("DeathType_int", 1);
            playerAnimator.SetBool("Death_b", true);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound);


        }
    }
}
