using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Text scoreText;
    private int score;
    public Text livesText;
    private int lives;
    public Text winText;
    public Text loseText;
    public float jumpForce;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;
    public AudioSource musicSource;
    Animator anim;
    private bool facingRight = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        score = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetScoreText();
        SetLivesText();
        musicSource.clip = musicClipOne;
        musicSource.Play();
    }
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.UpArrow))
        {
            anim.SetInteger("State",2);
        }
        if(Input.GetKeyUp (KeyCode.UpArrow))
        {
            anim.SetInteger("State",0);
        }
        if(Input.GetKeyDown (KeyCode.LeftArrow))
        {
            anim.SetInteger("State",1);
        }
        if(Input.GetKeyUp (KeyCode.LeftArrow))
        {
            anim.SetInteger("State",0);
        }
        if(Input.GetKeyDown (KeyCode.RightArrow))
        {
            anim.SetInteger("State",1);
        }
        if(Input.GetKeyUp (KeyCode.RightArrow))
        {
            anim.SetInteger("State",0);
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
        if (facingRight == false && moveHorizontal > 0)
        {
        Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
        Flip();
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.CompareTag ("Ground"))
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                
            }
        }   
    }
    void OnTriggerEnter2D(Collider2D other)
   {
        if (other.gameObject.CompareTag("PickUp"))
        {
           other.gameObject.SetActive(false);
           score = score + 1;
           SetScoreText();
           
        }
        if (other.gameObject.CompareTag ("Enemy PickUp"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetLivesText();
        }
        if (score == 4)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                transform.position= new Vector2(25f,-2f);
                lives = 3;
                SetLivesText();
            }
        }
        if (lives == 0)
        {
            gameObject.SetActive (false);
            loseText.text = "You Lose!";
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }
   }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString ();
        if (score >= 8)
        {
           winText.text = "You Win!";
           musicSource.clip = musicClipThree;
           musicSource.Play();
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString ();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
}