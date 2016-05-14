using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
	public GameObject[] prefabs;

	void Awake() {
	}

	private void ClearCanvas() {
		GameObject[] destroy = GameObject.FindGameObjectsWithTag ("Menus");
		foreach (GameObject go in destroy)
			Destroy (go);
	}

	public void LoadPrefab(int index) {
		ClearCanvas ();
		GameObject obj = Instantiate(prefabs[index]) as GameObject;
		obj.transform.SetParent(GameObject.Find("Canvas").transform);
		obj.transform.localScale = new Vector3 (1f, 1f, 1f);
		obj.transform.localPosition = new Vector3 (0, 0, 0);
	}

	public void Play(int difficulty) {
		SceneManager.LoadScene ("gamePlay");
	}
	/*
	public void Buy(int item, uint amount, uint price, int pay_type) {
		if (Pay(price, pay_type)) {
			switch(item) {
			case 1:
				GlobalData.item_moneybooster += amount;
				break;
			case 2:
				GlobalData.item_removepair += amount;
				break;
			case 3:
				GlobalData.item_timebooster += amount;
				break;
			default:
				break;
			}
			GlobalData.ability_updated = true;
		}
	}
	*/
	public void BuyMoneyBooster (int price) {
		if (Pay((uint) (int) price, 1)) {
			GlobalData.item_moneybooster += 1;
			GameManager.UpdateMoneyBooster ();
			GlobalData.ability_updated = true;
		}
	}
	
	public void BuyRemovePair (int price) {
		if (Pay((uint) (int) price, 1)) {
			GlobalData.item_removepair += 1;
			GameManager.UpdateRemovePair ();
			GlobalData.ability_updated = true;
		}
	}
	
	public void BuyTimeBooster (int price) {
		if (Pay((uint) (int) price, 1)) {
			GlobalData.item_timebooster += 1;
			GameManager.UpdateTimeBooster ();
			GlobalData.ability_updated = true;
		}
	}

	public void Buy1000Coin (int price) {
		if (Pay((uint) (int) price, 0)) {
			GlobalData.money += 1000;
			GameManager.UpdateMoney ();
			GlobalData.currency_updated = true;
		}
	}

	public void Buy10000Coin (int price) {
		if (Pay((uint) (int) price, 0)) {
			GlobalData.money += 10000;
			GameManager.UpdateMoney ();
			GlobalData.currency_updated = true;
		}
	}

	public void Buy100000Coin (int price) {
		if (Pay((uint) (int) price, 0)) {
			GlobalData.money += 100000;
			GameManager.UpdateMoney ();
			GlobalData.currency_updated = true;
		}
	}

	public void Buy10Gem (int price) {
		if (Pay((uint) (int) price, 0)) {
			GlobalData.gems += 10;
			GameManager.UpdateGems ();
			GlobalData.currency_updated = true;
		}
	}

	public void Buy100Gem (int price) {
		if (Pay((uint) (int) price, 0)) {
			GlobalData.gems += 100;
			GameManager.UpdateGems ();
			GlobalData.currency_updated = true;
		}
	}

	private bool Pay(uint price, int pay_type) {
		switch (pay_type) {
		case 1:
			if (GlobalData.money > price) {
				GlobalData.money -= price;
				GameManager.UpdateMoney ();
				GlobalData.currency_updated = true;
				return true;
			}
			return false;
		case 2:
			if (GlobalData.gems > price) {
				GlobalData.gems -= price;
				GameManager.UpdateGems ();
				GlobalData.currency_updated = true;
				return true;
			}
			return false;
		case 0:
			return true;
		default:
			return false;
		}
	}

	public void Exit() {
		Application.Quit ();
	}
}
