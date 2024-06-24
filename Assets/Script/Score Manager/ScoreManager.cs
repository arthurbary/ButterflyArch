using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public int baseScore = 100;
	public float multiplier = 1.1f;

	void Start()
	{
		GameData.Reset();
	}

	public void AddSurvivalDay()
	{
		GameData.daysSurvived++;
		CalculateScore();
	}

	private void CalculateScore()
	{
		int dayScore = (int)(baseScore * Mathf.Pow(multiplier, GameData.daysSurvived));
		GameData.totalScore += dayScore;
		Debug.Log("Day " + GameData.daysSurvived + " | Score for that day: " + dayScore + " | Total score: " + GameData.totalScore);
	}
}
