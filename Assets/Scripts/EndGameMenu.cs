using TMPro;
using UnityEngine;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] CanvasGroup CanvasGroup;
    [SerializeField] Color winColor;
    [SerializeField] Color loseColor;

    [SerializeField] TextMeshProUGUI[] allText; // For easiness I make title text first, reason - second

    public void GameEnd(string reason, bool win)
    {
        foreach (var text in allText)
            text.color = win ? winColor : loseColor;

        allText[0].text = win ? "Win!" : "Lose";
        allText[1].text = reason;
    }
}