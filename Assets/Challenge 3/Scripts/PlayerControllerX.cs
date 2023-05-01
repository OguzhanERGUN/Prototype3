using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public AudioClip jumpSound; 
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver )
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);

        }
        if (transform.position.y >= 15)
        {
            playerRb.velocity = Vector3.zero;
            transform.position = new Vector3(transform.position.x,14.99f,transform.position.z);
            playerRb.AddForce(Vector3.down * 7, ForceMode.Impulse);
        }
        else if (transform.position.y <= 0)
        {
            playerRb.velocity = Vector3.zero;
            transform.position = new Vector3(transform.position.x, 0.1f, transform.position.z);
            playerRb.AddForce(Vector3.up * 7, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound);
        }
        Debug.Log(playerRb.velocity);
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
