using UnityEngine;

public class SeekerProjectile : MonoBehaviour
{
    [System.Serializable]
    public class Projectile
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;

        public float getSpeed() { return speed; }
        public float getRotationSpeed() { return rotationSpeed; }
    }

    public Projectile projectile;
}
