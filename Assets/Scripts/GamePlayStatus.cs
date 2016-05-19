using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GamePlayStatus : MonoBehaviour {

	public float timeLeft;
	public bool stop = true;

	private float minutes;
	private float seconds;
	private int foundMatches = 0;
	private int coins = 0;
	private int coinsMultiplier = 1;

	public Text timerText;
	public Text foundMatchesText;
	public Text coinsText;
	public Text berhasilTimeText;
	public Text berhasilCoinsText;
	public Text notifText;
	public GameObject waktuHabis;
	public GameObject berhasil;
	public GameObject ARCamera;
	public GameObject moneyBoosterButton;
	public GameObject removePairButton;
	public GameObject timeBoosterButton;

	private HashSet<string> guessed = new HashSet<string>();

	void Start() {
		startTimer(90.0f);
		coinsText.text = coins.ToString();
		notifText.enabled = false;
		foundMatchesText.text = foundMatches + "/" + ListObject.getTotalCount () + " match";
		if (GlobalData.item_timebooster == 0)
			timeBoosterButton.GetComponent<Button> ().interactable = false;
		if (GlobalData.item_moneybooster == 0)
			moneyBoosterButton.GetComponent<Button> ().interactable = false;
		if (GlobalData.item_removepair == 0)
			removePairButton.GetComponent<Button> ().interactable = false;

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
		showMessage (objectName + " ditemukan!");
		// deactivateModel (objectName);
		var obj = GameObject.Find(objectName);
		if (obj != null)
			obj.transform.parent.gameObject.SetActive (false);
		ListObject.removeRemainingModel (objectName);
		foundMatches++;
		foundMatchesText.text = foundMatches + "/" + ListObject.getTotalCount () + " match";
		coins += 5*coinsMultiplier;
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
		GlobalData.money += (uint) (int)coins;
		GameManager.UpdateMoney ();
	}

	public void toMainMenu() {
		SplashAnimation.sequence = 0;
		SceneManager.LoadScene ("mainMenu");
	}

	public void restart() {
		SceneManager.LoadScene ("gamePlay");
	}

	private IEnumerator showMessage (string message) {
		notifText.text = message;
		notifText.gameObject.SetActive(true);
		yield return new WaitForSeconds(2.0f);
		notifText.gameObject.SetActive(false);
	}

	private IEnumerator deactivateModel(string objectName) {
		yield return new WaitForSeconds (1.0f);
		var obj = GameObject.Find(objectName);
		if (obj != null)
			obj.transform.parent.gameObject.SetActive (false);
	}

	public void moneyBooster() {
		GlobalData.item_moneybooster -= 1;
		GameManager.UpdateMoneyBooster ();
		GlobalData.ability_updated = true;
		showMessage ("x2 koin!");
		coins *= 2;
		coinsMultiplier = 2;
		moneyBoosterButton.GetComponent<Button> ().interactable = false;
	}

	public void removePair() {
		GlobalData.item_removepair -= 1;
		GameManager.UpdateRemovePair ();
		GlobalData.ability_updated = true;
		foundMatch (ListObject.getRemainingModel ());
		if (GlobalData.item_removepair == 0)
			removePairButton.GetComponent<Button> ().interactable = false;
	}

	public void timeBooster() {
		GlobalData.item_timebooster -= 1;
		GameManager.UpdateTimeBooster ();
		GlobalData.ability_updated = true;
		showMessage ("+10 detik!");
		timeLeft += 10.0f;
		if (GlobalData.item_timebooster == 0)
			timeBoosterButton.GetComponent<Button> ().interactable = false;
	}

}
