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

		int totalScore = GameData.totalScore;
		int daysSurvived = GameData.daysSurvived;

		scoreText.text = "Total Score: " + totalScore;
		daysSurvivedText.text = "Days Survived: " + daysSurvived;
	}
}
