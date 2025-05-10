using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public static GameControler Singleton;

    public BallController BallController;
    public Goal Goal;
    public Road Road;

    private void Start()
    {
        if(Singleton == null)
            Singleton = this;
        else
            Destroy(gameObject);
    }

    public void GameOver(string reason, bool win)
    {
        Debug.Log(win ? "Win: " : "Lose: " + reason);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}