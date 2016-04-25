using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia {
	public class MarkerCreator: MonoBehaviour {
		
		public GameObject marker;
		private MarkerTracker mt;

		void Start() {
			CameraDevice.Instance.Deinit ();
			mt = (MarkerTracker)TrackerManager.Instance.InitTracker<MarkerTracker> ();

			if (mt == null)
				Debug.Log ("NULL MARKER TRACKER");
			else {
				for (int id = 0; id < ListObject.getCount (); id++) {
					Debug.Log (id);
					MarkerBehaviour mb = (MarkerBehaviour)mt.CreateMarker (id, "marker" + id, 100);
					/*
				mb.gameObject.AddComponent <TrackableMarker>();
				mb.transform.position = new Vector3 (0, 0, 0);
				mb.transform.parent = gameObject.transform;*/
				}
			}
		}
	}
}


