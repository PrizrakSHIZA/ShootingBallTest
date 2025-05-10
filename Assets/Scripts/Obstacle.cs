using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public void Explode()
    {
        // Visual effects
        Destroy(gameObject);
    }
}