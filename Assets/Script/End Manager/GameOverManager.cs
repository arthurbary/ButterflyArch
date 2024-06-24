using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
	public TMP_Text gameOverText;

	void Start()
	{
		gameOverText.text = GameOverInfo.message;
	}
}
