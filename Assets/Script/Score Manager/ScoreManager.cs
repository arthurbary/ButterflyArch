using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public int baseScore = 100;
	public float multiplier = 1.1f;
	public int currentDay = 0;

	private int totalScore = 0;

	public void AddSurvivalDay()
	{
		currentDay++;
		CalculateScore();
	}

	private void CalculateScore()
	{
		int dayScore = (int)(baseScore * Mathf.Pow(multiplier, currentDay));
		totalScore += dayScore;
		Debug.Log("Day " + currentDay + " | Score for that day: " + dayScore + " | Total score: " + totalScore);
	}

	public int GetTotalScore()
	{
		return totalScore;
	}

	public int GetSurvivalDays()
	{
		return currentDay;
	}
}
