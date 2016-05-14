using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//GlobalData.player_name = PlayerPrefs.GetString ("player_name", "Player");
		//GlobalData.player_exp = (uint) (int) PlayerPrefs.GetInt ("player_exp", 0);
		//GlobalData.player_level = (uint) (int) PlayerPrefs.GetInt ("player_level", 1);
		//GlobalData.money = (uint) (int) PlayerPrefs.GetInt ("money", 0);
		//GlobalData.gems = (uint) (int) PlayerPrefs.GetInt ("gems", 0);
		//GlobalData.item_moneybooster = (uint) (int) PlayerPrefs.GetInt ("item_moneybooster", 0);
		//GlobalData.item_removepair = (uint) (int) PlayerPrefs.GetInt ("item_removepair", 0);
		//GlobalData.item_timebooster = (uint) (int) PlayerPrefs.GetInt ("item_timebooster", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	public static uint NextExp(uint level) {
		return (uint)((level) * 100 + (level - 1) * Mathf.Pow(50, level - 1));
	}

	public static void UpdateMoney() {
		PlayerPrefs.SetInt ("money", (int)GlobalData.money);
		PlayerPrefs.Save ();
	}

	public static void UpdateGems() {
		PlayerPrefs.SetInt ("gems", (int)GlobalData.gems);
		PlayerPrefs.Save ();
	}

	public static void UpdateMoneyBooster() {
		PlayerPrefs.SetInt ("item_moneybooster", (int)GlobalData.item_moneybooster);
		PlayerPrefs.Save ();
	}

	public static void UpdateRemovePair() {
		PlayerPrefs.SetInt ("item_removepair", (int)GlobalData.item_removepair);
		PlayerPrefs.Save ();
	}

	public static void UpdateTimeBooster() {
		PlayerPrefs.SetInt ("item_timebooster", (int)GlobalData.item_timebooster);
		PlayerPrefs.Save ();
	}

	public static void LevelUp() {
		GlobalData.player_level++;
		GlobalData.player_exp = 0;
		PlayerPrefs.SetInt ("player_level", (int)GlobalData.player_level);
		PlayerPrefs.SetInt ("player_exp", (int)GlobalData.player_exp);
		PlayerPrefs.Save ();
	}
}
