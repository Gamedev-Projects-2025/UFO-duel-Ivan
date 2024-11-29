using UnityEngine;

public class displayScore : MonoBehaviour
{
    [SerializeField] private NumberField currentScore;
    [SerializeField] private NumberField highScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Gets the high and current score from the score manager and displays it on screen
        currentScore.SetNumber(ScoreManager.Instance.getCurrentScore());
        highScore.SetNumber(ScoreManager.Instance.getHighScore());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
