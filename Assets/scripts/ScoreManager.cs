using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int CurrentScore;
    public int HighScore;

    //Used to transfer the score between the gameplay screen and the game over screen
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
    }

    public void UpdateHighScore()
    {
        if (CurrentScore > HighScore)
        {
            HighScore = CurrentScore;
        }
    }

    public int getHighScore()
    {
        return HighScore;
    }

    public int getCurrentScore()
    {
        return CurrentScore;
    }
}
