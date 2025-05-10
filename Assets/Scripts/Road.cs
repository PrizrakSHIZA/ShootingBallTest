using UnityEngine;

public class Road : MonoBehaviour
{
    int obstacles = 0;

    private void Update()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = GameControler.Singleton.BallController.transform.localScale.x;
        transform.localScale = newScale;
    }

    public void ObstacleDestroyed()
    {
        obstacles--;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
            obstacles++;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obstacle")
            obstacles--;

        if (obstacles <= 0)
            GameControler.Singleton.GameOver("Win!", true);
    }
}