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
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetScoreText();
        SetLivesText();
    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
        Application.Quit(); 
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }   
    }
    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
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
        transform.position= new Vector2(1f,1f);
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString ();
        if (score >= 4)
        {
           winText.text = "You Win!";
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString ();
        if (lives == 0)
        {
            loseText.text = "You Lose!";
        }
    }
}
