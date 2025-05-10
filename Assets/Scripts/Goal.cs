using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject door;

    void Update()
    {
        if (Vector3.Distance(transform.position, GameControler.Singleton.BallController.transform.position) < 5f)
        {
            door.SetActive(false);
        }
    }
}