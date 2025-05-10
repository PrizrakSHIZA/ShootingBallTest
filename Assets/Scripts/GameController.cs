using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public static GameControler Singleton;

    [SerializeField] EndGameMenu EndGameMenu;
    [SerializeField] Transform jumpEndPos;

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
            BallController.transform.DOJump(jumpEndPos.position, 5f, 3, 5f).SetEase(Ease.Linear).OnComplete(() =>
            {
                EndGameMenu.GameEnd(reason, true);
                EndGameMenu.gameObject.SetActive(true);
                EndGameMenu.GetComponent<CanvasGroup>().DOFade(1, 1f);
            });
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}