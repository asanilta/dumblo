using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GlobalData.player_name = PlayerPrefs.GetString ("player_name", "Player");
		GlobalData.player_exp = (uint) (int) PlayerPrefs.GetInt ("player_exp", 0);
		GlobalData.player_level = (uint) (int) PlayerPrefs.GetInt ("player_level", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}
