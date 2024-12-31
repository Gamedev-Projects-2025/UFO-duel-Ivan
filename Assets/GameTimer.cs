using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private float gameTime = 1f;
    private float timer = 0f;
    [SerializeField] private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            gameManager.LoadScene();
        }
        gameObject.GetComponent<NumberField>().SetNumber((int)timer);
        
    }
}
