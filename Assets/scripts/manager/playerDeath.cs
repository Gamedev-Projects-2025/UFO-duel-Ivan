using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDeath : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] private string sceneName; // Name of the scene to load
    [SerializeField] private NumberField score, lives;
    [SerializeField] private GameManager gameManager;

    //used when player collides with the enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            gameObject.GetComponent<Player>().Lives--;
            Destroy(other.gameObject);
            lives.SetNumber(gameObject.GetComponent<Player>().Lives);
            if (gameObject.GetComponent<Player>().Lives <= 0)
            {
                gameManager.LoadBadEnding();
            }
        }

    }

    public void Start()
    {
        score = UiManager.Instance.Score;
        lives = UiManager.Instance.Lives;
        lives.SetNumber(gameObject.GetComponent<Player>().Lives);
    }

    public void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }

}
