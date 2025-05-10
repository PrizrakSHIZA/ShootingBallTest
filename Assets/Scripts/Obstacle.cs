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
        
        //Because of unity bug where destroyed oibjects didnt trigger onTrigger events I added this method to properly counting obstacles
        GameControler.Singleton.Road.ObstacleDestroyed();
        Destroy(gameObject);
    }
}