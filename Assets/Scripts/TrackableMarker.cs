using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
public class TrackableMarker : MonoBehaviour, ITrackableEventHandler {
		private TrackableBehaviour mTrackableBehaviour;
		private GameObject model;
		private GameObject network;

		//private static bool trackedSingleFrameMarker = false;

		void Start ()
		{
			model = null;
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour) {
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
			network = GameObject.Find ("GameNetwork");
		}

		void Update ()
		{
		}
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{ 
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				//if (!trackedSingleFrameMarker)
				//{
					
					//trackedSingleFrameMarker = true;
					OnTrackingFound();
				//}
			}
			else
			{
				//trackedSingleFrameMarker = false;
				OnTrackingLost();
			}
		} 
		private void OnTrackingFound()
		{			
			if (model == null)
			{
				model = ListObject.getFreeModel();
				model.transform.parent = mTrackableBehaviour.transform;
			}
			if (model != null) {
				model.SetActive (true);
			}

			if (network == null)
				network = GameObject.Find ("GameNetwork");			
			if (network != null)
				network.GetComponent<NetworkMasterClient>().Guess (model.transform.name);
			//model.GetComponent<Renderer> ().enabled = true;			
			//GameObject.Find ("Model Name").GetComponent<Text> ().text = model.transform.name;
		}

		private void OnTrackingLost()
		{
			if (model != null) {
				model.SetActive (false);
				//model.GetComponent<Renderer> ().enabled = false;
				//GameObject.Find ("Model Name").GetComponent<Text> ().text = "";
			}
			if (network == null)
				network = GameObject.Find ("GameNetwork");
			if (network != null)
				network.GetComponent<NetworkMasterClient>().Guess ("");
			/*Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}*/
		

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}
	}
}