using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GlobalData.player_name = PlayerPrefs.GetString ("player_name", "Player");
		GlobalData.player_exp = (uint) (int) PlayerPrefs.GetInt ("player_exp", 0);
		GlobalData.player_level = (uint) (int) PlayerPrefs.GetInt ("player_level", 0);
		GlobalData.money = (uint) (int) PlayerPrefs.GetInt ("money", 0);
		GlobalData.gems = (uint) (int) PlayerPrefs.GetInt ("gems", 0);
		GlobalData.item_moneybooster = (uint) (int) PlayerPrefs.GetInt ("item_moneybooster", 0);
		GlobalData.item_removepair = (uint) (int) PlayerPrefs.GetInt ("item_removepair", 0);
		GlobalData.item_timebooster = (uint) (int) PlayerPrefs.GetInt ("item_timebooster", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	uint NextExp(uint level) {
		return (level + 1) * 100;
	}
}
