using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatisticManager : MonoBehaviour
{
    #region singleton
    public static StatisticManager Instance;
    private void Awake()
    {
        Instance = this;
        this.RegisterListener(EventID.OnGameEndlessOver, (x) => UpdateScoreStat());
        Load();
    }
    #endregion
    #region attribute
    public int levelCompleted;
    public int gamesPlayed;
    public int totalScore;
    public int bestScore;
    public float avgScore;
    public int totalGems;
    [SerializeField] TextMeshProUGUI gamePlayedTxt;
    [SerializeField] TextMeshProUGUI totalScoreTxt;
    [SerializeField] TextMeshProUGUI[] bestScoreTxt;
    [SerializeField] TextMeshProUGUI avgScoreTxt;
    [SerializeField] TextMeshProUGUI totalGemTxt;

    [SerializeField] TextMeshProUGUI lastScore;
    #endregion
    private void Start()
    {
        UpdateStat();
    }
    public void UpdateScoreStat()
    {
        ScoreManager.Instance.ExecuteBestScore();
        Instance.totalScore += ScoreManager.Instance.lastScoreInt;
        avgScore = totalScore * 1.0f / gamesPlayed;
    }
    public void UpdateStat()
    {
        gamePlayedTxt.text = gamesPlayed.ToString();
        totalScoreTxt.text = totalScore.ToString();
        foreach (TextMeshProUGUI t in bestScoreTxt)
            t.text = bestScore.ToString();
        avgScoreTxt.text = avgScore.ToString();
        totalGemTxt.text = totalGems.ToString();

        lastScore.text = ScoreManager.Instance.lastScoreInt.ToString();
        Save();
    }
    private void Save()
    {
        Debug.Log(gamesPlayed.ToString());
        PlayerPrefs.SetInt("gamesPlayed", gamesPlayed);
        PlayerPrefs.SetInt("totalScore", totalScore);
        PlayerPrefs.SetInt("bestScore", bestScore);
        PlayerPrefs.SetFloat("avgScore", avgScore);
        PlayerPrefs.SetInt("totalGems", totalGems);
    }
    private void Load()
    {
        gamesPlayed = PlayerPrefs.GetInt("gamesPlayed", 0);
        totalScore = PlayerPrefs.GetInt("totalScore", 0);
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        avgScore = PlayerPrefs.GetFloat("avgScore", 0);
        totalGems = PlayerPrefs.GetInt("totalGems", 0);
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save();
        }
    }
    private void OnApplicationQuit()
    {
        Save();
    }
}
