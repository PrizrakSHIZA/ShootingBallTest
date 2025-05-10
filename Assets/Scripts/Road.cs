using UnityEngine;

public class Road : MonoBehaviour
{
    int obstacles = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
            obstacles++;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obstacle")
            obstacles--;

        if (obstacles == 0)
            GameControler.Singleton.GameOver("Win!", true);
    }
}