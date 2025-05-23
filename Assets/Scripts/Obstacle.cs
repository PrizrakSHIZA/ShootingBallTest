using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    public Color color;

    [SerializeField] MeshRenderer renderer;

    Material material;

    private void Start()
    {
        material = renderer.material;
    }

    public void Explode()
    {
        // Visual effects
        material.DOColor(color, 1f).OnComplete(() => 
        {
            //Because of unity bug where destroyed oibjects didnt trigger onTrigger events I added this method to properly counting obstacles
            GameControler.Singleton.Road.ObstacleDestroyed();
            Destroy(gameObject);
        });
    }
}