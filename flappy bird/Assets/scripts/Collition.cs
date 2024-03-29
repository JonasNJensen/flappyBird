using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collition : MonoBehaviour
{
    public AudioClip deathSound;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI deathScoreText;
    public GameObject deathScreen;
    private int score = 0;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        deathScreen.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered: " + collision.tag);
        // Check if the player collides with a pillar
        if (collision.gameObject.CompareTag("Finish"))
        {
            KillPlayer();
        }

        // Check if the player collides with a goal
        if (collision.gameObject.CompareTag("Score"))
        {
            ScorePoint();
        }
    }

    void KillPlayer()
    {
        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
        Time.timeScale = 0f;
        if (deathScoreText != null)
        {
            deathScoreText.text = "Score: " + score;
        }
        deathScreen.SetActive(true);
        // You can implement actions like respawning or game over screen here
        Debug.Log("Player killed!");
        // For example, you might want to reload the scene or set the player's position to a respawn point.
        // You can add your own logic based on the game requirements.
    }

    void ScorePoint()
    {
        // Increment the score
        score++;

        // Update the score text
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Update the UI Text element to display the current score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
