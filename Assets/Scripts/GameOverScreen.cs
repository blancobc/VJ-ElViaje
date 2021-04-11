using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

	public GameObject getNamePanel;

	public Text yourScoreTxt;
	public Text highScoreTxt;
	public Text nameTxt;

	private int score;

	void Start()
	{
		pintarPuntuaciones();

		//TODO quitar
		PlayerPrefs.DeleteAll();
		// obtener el nombre del jugador
		string name = PlayerPrefs.GetString("name");
		
		// pedimos el nombre si no lo tenemos
		if (string.IsNullOrEmpty(name)) { getNamePanel.SetActive(true); }
		else { anadirDreamlo(); }

	}


	public void pintarPuntuaciones() {
		// puntuacion actual
		score = PlayerPrefs.GetInt("Score");
		yourScoreTxt.text = score.ToString();

		// puntuacion maxima
		if (score > PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", score);
			highScoreTxt.text = "Nuevo record: " + PlayerPrefs.GetInt("HighScore").ToString();


		}
		else
		{
			highScoreTxt.text = "Mejor: " + PlayerPrefs.GetInt("HighScore").ToString();
		}
	}

	public void anadirDreamlo() {
		Highscores.AddNewHighscore(PlayerPrefs.GetString("name"), score);
	}

	public void saveName()
	{
		PlayerPrefs.SetString("name", nameTxt.text);
		getNamePanel.SetActive(false);
		anadirDreamlo();
	}


}
