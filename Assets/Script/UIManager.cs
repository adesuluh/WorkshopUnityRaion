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

		//Update score dengan Invoke, Parameter berisi String yang merujuk pada method scoreUpdate, waktu invoke dan repeatRate nya
		InvokeRepeating ("scoreUpdate", 1.0f, 2.0f);

	}

	// Update is called once per frame

	void Update () {


		//highscore
		storeHighScore (score);
		scoreText.text = "Score: " + score + " Miles";
		//Menyimpan highsor edengan palyerpref
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
		
	//method untuk menyimpan highscore
	void storeHighScore(int newHighscore) {

		//membuat variabel baru dan get tipe integer score dengan tag "highscore" dan set ke 0 (utk pertama kali main)
		int oldHighscore = PlayerPrefs.GetInt("highscore", 0);    
		//Jika score baru lebih besar dari score lama
		if(newHighscore > oldHighscore)
		{
			//Menset highscore dengan playerpref dengan nilai baru yaitu newHighscore
			PlayerPrefs.SetInt("highscore", newHighscore);
			oldHighscore = newHighscore;
			//Menyimpan score ke variabel local
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
