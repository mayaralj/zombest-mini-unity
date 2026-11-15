using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] PlayerController player;
    [SerializeField] EnemySpawner spawner;
    int score;
    public bool gameOver;
    public static GameManager Instance;

    void Awake()
    {
        // Set the static Instance to this instance of GameManager
        Instance = this;
    }

    public void AddScore(int amount)
    {
        // Add the amount to score and update the scoreText
        score += amount;

        // Update the scoreText to show the new score
        scoreText.text = "Score: " + score.ToString();
    }

    public void SetHealth(int health)
    {
        // Update the healthText to show the new health
        healthText.text = "Health: " + health.ToString();
    }

    public void GameOver()
    {
        // Set gameOver to true, show the gameOverText, and disable the player and spawner
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
    }

    void Update()
    {
        // If game over and R was pressed
        if (gameOver && Keyboard.current.rKey.wasPressedThisFrame)
        {
            // Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}