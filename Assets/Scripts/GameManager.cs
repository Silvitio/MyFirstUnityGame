using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        UpdateScore();
        gameOverText.gameObject.SetActive(false);
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}
