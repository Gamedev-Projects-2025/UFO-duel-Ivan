using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string sceneName, badEnding;
    [SerializeField] private NumberField score, lives;
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            //Transfering score between screens
            ScoreManager.Instance.CurrentScore = score.GetNumber();
            ScoreManager.Instance.UpdateHighScore();
            SceneManager.LoadScene(sceneName);
        }
    }

    public void LoadBadEnding()
    {
        if (!string.IsNullOrEmpty(badEnding))
        {
            SceneManager.LoadScene(badEnding);
        }
    }

    public void Start()
    {
        score = UiManager.Instance.Score;
    }
}
