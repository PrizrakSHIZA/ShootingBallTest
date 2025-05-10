using UnityEngine;

public class BallShot : MonoBehaviour
{
    public float power = 1f;

    void OnCollisionEnter(Collision collision)
    {
        Collider[] infected = Physics.OverlapSphere(transform.position, power);
        foreach (var col in infected)
        {
            if (col.CompareTag("Obstacle"))
            {
                col.GetComponent<Obstacle>().Explode();
            }
        }

        Destroy(gameObject);
    }
}