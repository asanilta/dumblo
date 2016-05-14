using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelCount : MonoBehaviour {
	public Text level_text;
	// Use this for initialization
	void Start () {
		level_text.text = GlobalData.player_level.ToString ();
	}

	// Update is called once per frame
	void Update () {
		if (GlobalData.level_updated) {
			GameManager.LevelUp ();
			level_text.text = GlobalData.player_level.ToString ();
			GlobalData.level_updated = false;
		}
	}
}
