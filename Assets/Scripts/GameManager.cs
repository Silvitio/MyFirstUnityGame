using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;               // Счётчик количества собранных объектов
    public TextMeshProUGUI scoreText;   // Ссылка на компонент TextMeshPro

    void Start()
    {
        UpdateScore();
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
}
