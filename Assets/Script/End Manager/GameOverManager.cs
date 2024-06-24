using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
	public TMP_Text gameOverText;
	public TMP_Text scoreText, daysSurvivedText;

	void Start()
	{
		gameOverText.text = GameOverInfo.message;

		ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

		int totalScore = scoreManager.GetTotalScore();
		int daysSurvived = scoreManager.GetSurvivalDays();

		scoreText.text = "Total Score: " + totalScore;
		daysSurvivedText.text = "Days Survived: " + daysSurvived;
	}
}
