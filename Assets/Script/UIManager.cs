using UnityEngine;
using System.Collections;
//for text score
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;
	int score;
	bool gameOver;

	public Button[] buttons;

	// Use this for initialization
	void Start () {
		gameOver = false;

	
		InvokeRepeating ("scoreUpdate", 1.0f, 2.0f);
	}

	// Update is called once per frame

	void Update () {


		//highscore
		storeHighScore (score);
		scoreText.text = "Score: " + score + " Miles";
		highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore");
		//scoreUpdate (); terlalu cepat pake invoke
	}

	public void GameOver() {
		gameOver = true;

		foreach(Button button in buttons) {
			button.gameObject.SetActive (true);
		}
	}

	void scoreUpdate() {
		if(gameOver == false) {
		score += 1;
		}
	}
		
	//high score
	void storeHighScore(int newHighscore) {
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		if(newHighscore > oldHighscore)
		{
			PlayerPrefs.SetInt("highscore", newHighscore);
			oldHighscore = newHighscore;
			PlayerPrefs.Save();
		}
	}

	public void Play() {
		Application.LoadLevel ("Level1");
	}
	public void Pause() {
		if(Time.timeScale == 1) {
			Time.timeScale = 0;
		} else if(Time.timeScale == 0) {
			Time.timeScale = 1; 
		}
	}

	public void replay() {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void exit() {
		Application.Quit ();
	}
}
