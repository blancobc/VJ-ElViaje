/*
 * Copyright (c) 2017 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

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
