using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BirdJump : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpPower = 3.0f;
    public AudioClip[] ad;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().clip = ad[Random.Range(0, 2)];
            GetComponent<AudioSource>().Play();
            rb.velocity = Vector2.up * jumpPower;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Score.score > Score.bestScore)
        {
            Score.bestScore = Score.score;
        }
        SceneManager.LoadScene("GameOverScene");
    }
}