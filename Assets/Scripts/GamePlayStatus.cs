using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GamePlayStatus : MonoBehaviour {

	public float timeLeft;
	public bool stop = true;

	private float minutes;
	private float seconds;
	private int foundMatches = 0;
	private int coins = 0;

	public Text timerText;
	public Text foundMatchesText;
	public Text coinsText;
	public Text berhasilTimeText;
	public Text berhasilCoinsText;
	public Text notifText;
	public GameObject waktuHabis;
	public GameObject berhasil;
	public GameObject ARCamera;

	void Start() {
		startTimer(90.0f);
		coinsText.text = coins.ToString();
		foundMatchesText.text = foundMatches + "/" + ListObject.getTotalCount () + " match";
	}

	public void startTimer(float from){
		stop = false;
		timeLeft = from;
		Update();
		StartCoroutine(updateCoroutine());
	}

	void Update() {
		if (!stop) {
			timeLeft -= Time.deltaTime;

			minutes = Mathf.Floor (timeLeft / 60);
			seconds = timeLeft % 60;
			if (seconds > 59)
				seconds = 59;
			if (minutes < 0) {
				stop = true;
				minutes = 0;
				seconds = 0;
				timeUp ();
			}
		}
		//        fraction = (timeLeft * 100) % 100;
	}

	private IEnumerator updateCoroutine(){
		while(!stop){
			timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
			yield return new WaitForSeconds(0.2f);
		}
	}

	public void foundMatch(string objectName) {
		ShowMessage ();
		GameObject.Find (objectName).transform.parent.gameObject.SetActive (false);
		foundMatches++;
		foundMatchesText.text = foundMatches + "/" + ListObject.getTotalCount () + " match";
		coins += 5;
		coinsText.text = coins.ToString();
		if (foundMatches == ListObject.getTotalCount ()) {
			winGame ();
		}
	}

	private void timeUp() {
		waktuHabis.SetActive (true);
		ARCamera.SetActive (false);
	}

	private void winGame() {
		stop = true;
		berhasilTimeText.text = timerText.text;
		berhasilCoinsText.text = coinsText.text;
		berhasil.SetActive (true);
		ARCamera.SetActive (false);
	}

	public void toMainMenu() {
		SceneManager.LoadScene ("mainMenu");
	}

	public void restart() {
		SceneManager.LoadScene ("gamePlay");
	}

	IEnumerator ShowMessage () {
		notifText.enabled = true;
		yield return new WaitForSeconds(2.0f);
		notifText.enabled = false;
	}

}
