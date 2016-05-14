using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCount : MonoBehaviour {
	public Text ability_coin_text;
	public Text ability_card_text;
	public Text ability_time_text;

	// Use this for initialization
	void Start () {
		ability_coin_text.text = GlobalData.item_moneybooster.ToString ();
		ability_card_text.text = GlobalData.item_removepair.ToString ();
		ability_time_text.text = GlobalData.item_timebooster.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalData.ability_updated) {
			ability_coin_text.text = GlobalData.item_moneybooster.ToString ();
			ability_card_text.text = GlobalData.item_removepair.ToString ();
			ability_time_text.text = GlobalData.item_timebooster.ToString ();
			GlobalData.ability_updated = false;
		}
	}
}
