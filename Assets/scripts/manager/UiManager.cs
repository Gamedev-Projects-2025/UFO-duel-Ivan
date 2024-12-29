using UnityEngine;

public class UiManager: MonoBehaviour
{
    public static UiManager Instance;
    [SerializeField] private NumberField score, lives, charge;

    public NumberField Score { get => score;}
    public NumberField Lives { get => lives;}
    public NumberField Charge { get => charge;}
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(Instance);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
