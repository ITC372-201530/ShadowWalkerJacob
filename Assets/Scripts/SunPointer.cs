using UnityEngine;
using System.Collections;

public class SunPointer : MonoBehaviour {

	public GameObject goToTrack;
	public Camera Maincamera;

	void Start(){
		goToTrack = GameObject.FindGameObjectWithTag ("Sun");
	}

	void Update () {
		Vector3 v3Screen = Maincamera.WorldToViewportPoint(goToTrack.transform.position);
		if (v3Screen.x > -0.01f && v3Screen.x < 1.01f && v3Screen.y > -0.01f && v3Screen.y < 1.01f)
			this.transform.position = Maincamera.transform.position * 1000;
		else
		{	

			v3Screen.x = Mathf.Clamp (v3Screen.x, 0.01f, 0.99f);
			v3Screen.y = Mathf.Clamp (v3Screen.y, 0.01f, 0.99f);

			if(v3Screen.x <= 0.3f)
				transform.rotation =  Quaternion.Euler(0,0,90);
			else if (v3Screen.x >= 0.97f)
				transform.rotation =  Quaternion.Euler(0,0,270);
			else
				transform.rotation =  Quaternion.Euler(0,0,0);
			
			transform.position = Maincamera.ViewportToWorldPoint (v3Screen);
		}
		
	}

}
