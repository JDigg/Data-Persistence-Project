using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TMP_Text bestScoreText;
    private void Start()
    {
        playerNameInput.text = GameManager.Instance.playerName;

        var m = GameManager.Instance;
        bestScoreText.text = m.bestScore > 0
            ? $"Best Score: {m.bestPlayerName} : {m.bestScore}"
            : "Best Score: 0";
    }

    public void StartGame()
    {
        GameManager.Instance.SetPlayerName(playerNameInput.text);
        SceneManager.LoadScene(1);
    }

}
