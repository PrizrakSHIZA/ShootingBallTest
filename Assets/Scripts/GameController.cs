using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public static GameControler Singleton;

    [SerializeField] EndGameMenu EndGameMenu;

    public BallController BallController;
    public Goal Goal;
    public Road Road;
    public bool GameEnded = false;

    private void Start()
    {
        if(Singleton == null)
            Singleton = this;
        else
            Destroy(gameObject);
    }

    public void GameOver(string reason, bool win)
    {
        GameEnded = true;
        if (!win)
        {
            EndGameMenu.GameEnd(reason, false);
            EndGameMenu.gameObject.SetActive(true);
            EndGameMenu.GetComponent<CanvasGroup>().DOFade(1, 1f);
        }
        else
        { 
            
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}