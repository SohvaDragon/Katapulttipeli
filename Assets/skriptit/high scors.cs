using UnityEngine;

public class highscors : MonoBehaviour
{
    public static highscors Instance;

    private int highScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        highScore = PlayerPrefs.GetInt("Highscore");
    }

    public void UpdateScore(int points)
    {
        if (points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
    }


    public int GetHighScore()
    {
        return highScore;
    }
}
