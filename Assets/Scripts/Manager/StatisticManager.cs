using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatisticManager : MonoBehaviour
{
    public static StatisticManager Instance;
    private void Awake()
    {
        Instance = this;
        this.RegisterListener(EventID.OnGameEndlessOver, (x) => UpdateScoreStat());
    }
    public void UpdateScoreStat()
    {

        ScoreManager.Instance.ExecuteBestScore();
        Instance.totalScore += ScoreManager.Instance.lastScoreInt;
        avgScore = totalScore * 1.0f / gamesPlayed;
    }

    public int levelCompleted;
    public int gamesPlayed;
    public int totalScore;
    public int bestScore;
    public float avgScore;
    public int totalGems;
    [SerializeField] TextMeshProUGUI lvlCompletedTxt;
    [SerializeField] TextMeshProUGUI gamePlayedTxt;
    [SerializeField] TextMeshProUGUI totalScoreTxt;
    [SerializeField] TextMeshProUGUI[] bestScoreTxt;
    [SerializeField] TextMeshProUGUI avgScoreTxt;
    [SerializeField] TextMeshProUGUI totalGemTxt;

    [SerializeField] TextMeshProUGUI lastScore;

    private void Start()
    {
        Load();
        UpdateStat();
    }
    public void UpdateStat()
    {
        lvlCompletedTxt.text = "Levels completed: " + levelCompleted.ToString();
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
        PlayerPrefs.SetInt("levelCompleted", levelCompleted);
        PlayerPrefs.SetInt("gamesPlayed", gamesPlayed);
        PlayerPrefs.SetInt("totalScore", totalScore);
        PlayerPrefs.SetInt("bestScore", bestScore);
        PlayerPrefs.SetFloat("avgScore", avgScore);
        PlayerPrefs.SetInt("totalGems", totalGems);
    }
    private void Load()
    {
        levelCompleted = PlayerPrefs.GetInt("levelCompleted", 0);
        gamesPlayed = PlayerPrefs.GetInt("gamesPlayed", 0);
        totalScore = PlayerPrefs.GetInt("totalScore", 0);
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        avgScore = PlayerPrefs.GetFloat("avgScore", 0);
        totalGems = PlayerPrefs.GetInt("totalGems", 0);
    }
}
