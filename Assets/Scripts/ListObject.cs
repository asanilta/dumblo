using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListObject : MonoBehaviour {
	private static List<GameObject> freeModels = new List<GameObject>();

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
		return model;
	}

	public static int getCount() {
		return freeModels.Count;
	}

}
