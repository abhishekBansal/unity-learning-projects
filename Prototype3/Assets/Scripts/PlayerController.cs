using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerSfx;
    private bool isOnGround = true;

    public float jumpForce = 10;
    public float gravityModifier = 1f;
    public bool isGameOver = false;
    public ParticleSystem deathExplosion;
    public ParticleSystem dirtSplatter;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        playerSfx = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver) {
            jump();
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtSplatter.Stop();
            playerSfx.PlayOneShot(jumpSound, 1);
            //jumpSound.
        }
    }

    void jump() {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") {
            isOnGround = true;
            dirtSplatter.Play();
        }
        else if (collision.gameObject.tag == "Obstacle") {
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            deathExplosion.Play();
            dirtSplatter.Stop();
            playerSfx.PlayOneShot(crashSound, 1);
        }
    }
}
