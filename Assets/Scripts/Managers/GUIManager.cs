
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GUIManager : MonoBehaviour {
	public static GUIManager instance;

	public Text scoreTxt;
	public Text moveCounterTxt;

	public int moveCounter = 10;
	public int moveCounterBonus = 1;
	public int scorePerMatch = 5;

    private int score;

	public int Score
	{
		get
		{
			return score;
		}

		set
		{
			score = value;
			scoreTxt.text = score.ToString();
		}
	}

	public int MoveCounter
	{
		get
		{
			return moveCounter;
		}

		set
		{
			moveCounter = value;
			moveCounterTxt.text = moveCounter.ToString();

			if (moveCounter <= 0)
			{
				moveCounter = 0;
				GameOver();
			}

		}
	}


	void Awake() {
		moveCounterTxt.text = moveCounter.ToString();

		instance = GetComponent<GUIManager>();
	}

	// Show the game over panel
	public void GameOver() {

		GameManager.instance.gameOver = true;

		PlayerPrefs.SetInt("Score", score);

		GameManager.instance.LoadScene("GameOver");

	}


}
