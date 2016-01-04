using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public Text scoreText;
	public Button restartButton;

	[HideInInspector]
	public bool isRunning;
	[HideInInspector]
	public int score;
	
	void Awake () 
	{
		Time.timeScale = 1;
		isRunning = true;
		score = 0;
		SetScore ();
		restartButton.gameObject.SetActive(false);
	}

	void Update () 
	{
		if (isRunning)
		{
			score += 1;
			SetScore ();
		}

	}

	void SetScore() 
	{
		scoreText.text = "Score: " + score;
	}

	void FinishGame() 
	{
		Time.timeScale = 0;
		restartButton.gameObject.SetActive(true);
		isRunning = false;

	}

	void RestartGame() 
	{
		Application.LoadLevel ("playing");
	}
}
