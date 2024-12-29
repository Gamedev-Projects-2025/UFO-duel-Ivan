using UnityEngine;

[System.Serializable]
public class Player: MonoBehaviour
{
    [SerializeField] private float speed, speedUpModifier, speedDownModifier;
    [SerializeField] private int lives;

    public float Speed { get => speed; set => speed = value; }
    public int Lives { get => lives; set => lives = value; }
    public float SpeedUpModifier { get => speedUpModifier; set => speedUpModifier = value; }
    public float SpeedDownModifier { get => speedDownModifier; set => speedDownModifier = value; }
}
