
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class GUIManager : MonoBehaviour {
	public static GUIManager instance;

	public Text scoreTxt;
	public Text moveCounterTxt;
	public Text levelTxt;

	public int moveCounter = 5;
	public int moveCounterBonus = 1;
	public int scorePerMatch = 5;
	public int charactersUnlocked = 4;

	public int _level = 1;
	public int level
	{
		get
		{
			return _level;
		}

		set
		{
			_level = value;
			levelTxt.text = _level.ToString();

			if (level == 1) {
				moveCounterBonus = 0;
				scorePerMatch = 2;
				charactersUnlocked = 7;
			}
			if (level == 2)
			{
				moveCounterBonus = 1;
				scorePerMatch = 4;
				charactersUnlocked = 8;
			}
			if (level == 3)
			{
				moveCounterBonus = 1;
				scorePerMatch = 6;
				charactersUnlocked = 9;
			}
			if (level == 4)
			{
				moveCounterBonus = 1;
				scorePerMatch = 8;
				charactersUnlocked = 10;
			}

		}
	}

	private int _score;

	public int Score
	{
		get
		{
			return _score;
		}

		set
		{
			_score = value;
			scoreTxt.text = _score.ToString();

			if ( (_score > 200 && level==1) ||
				(_score > 400 && level == 2) ||
				(_score > 600 && level == 3) ||
				(_score > 800 && level == 4)
				)
				level++;

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
		levelTxt.text = level.ToString();

		instance = GetComponent<GUIManager>();
	}

	// Show the game over panel
	public void GameOver() {

		GameManager.instance.gameOver = true;

		PlayerPrefs.SetInt("Score", Score);

		GameManager.instance.LoadScene("GameOver");

	}


}
