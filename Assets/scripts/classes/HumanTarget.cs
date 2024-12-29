using UnityEngine;

public class HumanTarget : MonoBehaviour
{
    [System.Serializable]
    public class Human
    {
        [SerializeField] private int score = 0;

        public int getScore() { return score; }
    }
    public Human target;
}
