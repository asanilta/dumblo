using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListObject : MonoBehaviour {
	private static List<GameObject> freeModels = new List<GameObject>();
	private static List<string> remainingModels = new List<string>();
	private static int totalCount = 6;

	void Awake () {
		Object[] objects = Resources.LoadAll("Prefabs");
		foreach (Object obj in objects) {
			freeModels.Add ((GameObject)obj);
		}
	}

	public static GameObject getFreeModel() {
		int index = Random.Range (0, freeModels.Count);
		GameObject model = GameObject.Instantiate (freeModels [index]);
		model.transform.name = freeModels [index].transform.name;
		freeModels.RemoveAt (index);
		remainingModels.Add (model.transform.name);
		return model;
	}

	public static string getRemainingModel() {
		int index = Random.Range (0, remainingModels.Count);
		return remainingModels [index];
	}

	public static void removeRemainingModel(string name) {
		remainingModels.Remove (name);
	}
		

	public static int getTotalCount() {
		return totalCount;
	}

}
