using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text bestScoreText;

    private void Start()
    {
        playerNameText.text = GameManager.Instance.playerName;
        RefreshBestScore();
    }

    public void RefreshBestScore()
    {
        var m = GameManager.Instance;
        bestScoreText.text = m.bestScore > 0
            ? $"Best Score: {m.bestPlayerName} : {m.bestScore}"
            : "Best Score: none yet";
    }
}