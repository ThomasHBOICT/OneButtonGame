using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    
    public GameObject jumpDirection;

    public bool canJump = true;

    private Rigidbody2D rb;

    private Animator playerAnimation;
    private SpriteRenderer sprite;
    private JumpDirection directionScript;
    public SpriteRenderer jumpArrow;

    public FloatValue highScore;
    public FloatValue currentScore;

    [HideInInspector]
    public AudioManager audioManager;

    public bool camShakeEnabled = true;
    public CMCamShake camShake;


    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentScore.@float = 0;
        //Time.timeScale = 0;
        rb = GetComponent<Rigidbody2D>();
        
        playerAnimation = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        directionScript = GetComponentInChildren<JumpDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        JumpActiveVisual();
        ScoreUpdater();
    }

    private void Jump()
    {
        if (Input.anyKeyDown && canJump || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && canJump)
        {
            canJump = false;
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(jumpDirection.transform.up * jumpForce);
            audioManager.Play("jump");
            if (camShakeEnabled)
            {
                camShake.CamShake(0.2f);

            }
            playerAnimation.SetBool("isJumping", true);

            if (directionScript.tickerRightSide)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            directionScript.FlipDirection();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            CanJump();
        }
    }

    private void CanJump()
    {
        playerAnimation.SetBool("isJumping", false);
        canJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Orb")
        {
            FindObjectOfType<AudioManager>().Play("orb");
            collision.GetComponent<Orb>().Pickup();
            canJump = true;
        }
    }

    private void JumpActiveVisual()
    {
        if (canJump)
        {
            jumpArrow.color = new Color(1, 1, 1, 1);
        }
        else
        {
            jumpArrow.color = new Color(1, 1, 1, 0.2f);
        }
    }

    private void ScoreUpdater()
    {
        if (transform.position.y > highScore.@float)
        {
            highScore.@float = transform.position.y;
        }
        if (transform.position.y > currentScore.@float)
        {
            currentScore.@float = transform.position.y;
        }
    }
}
