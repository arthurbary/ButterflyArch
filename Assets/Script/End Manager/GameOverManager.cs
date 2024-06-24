using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
	public TMP_Text gameOverText;
	public TMP_Text scoreText;

	void Start()
	{
		gameOverText.text = GameOverInfo.message;

		int totalScore = FindObjectOfType<ScoreManager>().GetTotalScore();
		scoreText.text = "Total Score: " + totalScore;
	}
}
