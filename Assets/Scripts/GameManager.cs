using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
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

	public static void UpdateAvatar() {
		PlayerPrefs.SetInt ("player_gender", (int)GlobalData.player_gender);
		PlayerPrefs.SetInt ("avatar_hair", (int)GlobalData.avatar_hair);
		PlayerPrefs.SetInt ("avatar_top", (int)GlobalData.avatar_top);
		PlayerPrefs.SetInt ("avatar_bottom", (int)GlobalData.avatar_bottom);
		PlayerPrefs.Save ();
	}

	public static void UpdateName() {
		PlayerPrefs.SetString ("player_name", GlobalData.player_name);
		PlayerPrefs.Save ();
	}
}
