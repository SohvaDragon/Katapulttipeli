using UnityEngine;
using TMPro;

public class scoremanager : MonoBehaviour
{
    public static scoremanager Instance;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highScoreText;

    private int score;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score =+ points;
        highscors.Instance.UpdateScore(score);
        UpdateUI();
    }
    void UpdateUI()
    {
        scoreText.text = "score: " + score;
        highScoreText.text = "Highscore: " + highscors.Instance.GetHighScore();
    }
}
