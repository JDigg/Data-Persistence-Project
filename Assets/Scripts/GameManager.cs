using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName = "Player";
    public int bestScore;
    public string bestPlayerName = "";

    private const string nameKey = "playerName";
    private const string bestScoreKey = "bestScore";
    private const string bestNameKey = "bestPlayerName";

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    public void SetPlayerName(string newName)
    {
        playerName = string.IsNullOrEmpty(newName) ? "Player" : newName;
        PlayerPrefs.SetString(nameKey, playerName);
        PlayerPrefs.Save();
    }
    public bool SubmitScore (int score)
    {
        if (score <= bestScore) return false;
        bestScore = score;
        bestPlayerName = playerName;

        PlayerPrefs.SetInt(bestScoreKey, bestScore);
        PlayerPrefs.SetString(bestNameKey, bestPlayerName);
        PlayerPrefs.Save();
        return true;
    }
    private void Load()
    {
        playerName = PlayerPrefs.GetString(nameKey, "Player");
        bestScore = PlayerPrefs.GetInt(bestScoreKey, 0);
        bestPlayerName = PlayerPrefs.GetString(bestNameKey, "");
    }
}
