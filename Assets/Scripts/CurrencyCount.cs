using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrencyCount : MonoBehaviour {
	public Text currency_money_text;
	public Text currency_gems_text;

	// Use this for initialization
	void Start () {
		currency_money_text.text = GlobalData.money.ToString ();
		currency_gems_text.text = GlobalData.gems.ToString ();
	}

	// Update is called once per frame
	void Update () {
		if (GlobalData.currency_updated) {
			currency_money_text.text = GlobalData.money.ToString ();
			currency_gems_text.text = GlobalData.gems.ToString ();
			GlobalData.currency_updated = false;
		}
	}
}
