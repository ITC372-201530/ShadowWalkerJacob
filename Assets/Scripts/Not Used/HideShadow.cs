using UnityEngine;
using System.Collections;

public class HideShadow : MonoBehaviour {
	GameObject [] shadows;
	public GameObject player;
	public GameObject pushable;

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Sun"){		
			if (player.transform.parent != null)			
				if (player.transform.parent.tag.Equals ("ShadowHolder"))				
					player.transform.parent = null;

			if (pushable.transform.parent != null)			
				if (pushable.transform.parent.tag.Equals ("ShadowHolder"))				
					pushable.transform.parent = null;

			shadows = GameObject.FindGameObjectsWithTag ("Shadow");
			foreach (GameObject sdw in shadows) 			
				sdw.SetActive (false);	
		}
	}
	
	void OnTriggerExit (Collider col)
	{
		if (col.tag == "Sun")		
			foreach (GameObject sdw in shadows){
				sdw.SetActive (true);
				sdw.collider.enabled = false;
			}
	}

}
