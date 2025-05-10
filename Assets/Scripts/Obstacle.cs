using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] MeshRenderer renderer;

    Material material;

    private void Start()
    {
        material = renderer.material;
    }

    public void Explode()
    {
        // Visual effects
        Destroy(gameObject);
    }
}