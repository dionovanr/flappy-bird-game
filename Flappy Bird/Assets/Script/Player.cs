using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject GameOver;
    public float JumpForce;
    public int score, hiScore;
    public Text scoreUI, hiScoreUI;
    string HIGHSCORE = "High Score";

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        hiScore = PlayerPrefs.GetInt(HIGHSCORE);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.singleton.PlaySound(0);
            rb.velocity = Vector2.up * JumpForce;
        }
    }

    void mati()
    {
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt(HIGHSCORE, hiScore);
        }
        hiScoreUI.text = "High Score: " + hiScore.ToString();
        GameOver.SetActive(true);
        Time.timeScale = 0;
        AudioManager.singleton.PlaySound(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            mati();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("score"))
        {
            AddScore();
        }
    }

    void AddScore()
    {
        AudioManager.singleton.PlaySound(2);
        score++;
        scoreUI.text = "Score: " + score.ToString();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
