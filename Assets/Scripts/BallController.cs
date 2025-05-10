using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject shotPrefab;
    public Transform shotSpawnPoint;
    public float minSize = 0.3f;
    public float shotGrowRate = 0.5f;
    public float shootForce = 15f;

    GameObject currentShot;
    bool isCharging = false;
    float initialScale;

    void Start()
    {
        initialScale = transform.localScale.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCharging();
        }
        else if (Input.GetMouseButton(0) && isCharging)
        {
            ChargeShot();
        }
        else if (Input.GetMouseButtonUp(0) && isCharging)
        {
            ReleaseShot();
        }
    }

    void StartCharging()
    {
        isCharging = true;
        currentShot = Instantiate(shotPrefab, shotSpawnPoint.position, Quaternion.identity);
        currentShot.transform.localScale = Vector3.one * 0.1f;
    }

    void ChargeShot()
    {
        float growAmount = shotGrowRate * Time.deltaTime;
        currentShot.transform.localScale += Vector3.one * growAmount;

        float shrinkAmount = growAmount;
        transform.localScale -= Vector3.one * shrinkAmount;

        if (transform.localScale.x <= minSize)
        {
            GameControler.Singleton.GameOver("Lost all energy!", false);
        }
    }

    void ReleaseShot()
    {
        isCharging = false;
        Rigidbody rb = currentShot.AddComponent<Rigidbody>();
        Vector3 direction = (GameControler.Singleton.Goal.transform.position - transform.position).normalized;
        rb.velocity = direction * shootForce;
        currentShot.GetComponent<BallShot>().power = currentShot.transform.localScale.x;
        currentShot = null;
    }
}
