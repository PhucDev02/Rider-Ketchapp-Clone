using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    private void Awake()
    {
        Instance = this;
        Load();
    }

    [SerializeField] Transform vehicle;
    private float currentHighestDistance;
    [SerializeField] TextMeshProUGUI score;

    private string lastScore;
    public int lastScoreInt;
    private void Update()
    {
        if (vehicle.position.x > currentHighestDistance)
        {
            currentHighestDistance = vehicle.position.x;
        }
        lastScore = score.text;
        score.text = Math.Round(currentHighestDistance / 10).ToString();

        if (score.text != lastScore && int.Parse(score.text) % 3 == 0)
            MapGenerator.Instance.GenNextTerrain();
    }
    public void ExecuteBestScore()
    {
        lastScoreInt = (int)Math.Ceiling((Math.Round(currentHighestDistance / 10)));
        if(lastScoreInt>StatisticManager.Instance.bestScore)
        {
            StatisticManager.Instance.bestScore = lastScoreInt;
        }
        Save();
    }
    public void ResetScore()
    {
        currentHighestDistance = 0;
        score.text = "0";
        lastScore = score.text;
        MapGenerator.Instance.Reset();
    }
    private void Load()
    {
        lastScoreInt = PlayerPrefs.GetInt("lastScore", 0);
    }
    private void Save()
    {
        PlayerPrefs.SetInt("lastScore", lastScoreInt);
    }
}
