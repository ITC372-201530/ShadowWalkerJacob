using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
	
	private Vector3 sunPosition;
	private Vector3 parentPosition;
	public Color originalColour;
	public float newAlpha;
	Vector3 sun_X = Vector3.zero;
	Vector3 parent_X = Vector3.zero;




	void Update () {

		sun_X.x = sunPosition.x;
		parent_X.x = parentPosition.x;

		sunPosition = GameObject.FindGameObjectWithTag ("Sun").transform.position;
		parentPosition = transform.parent.position;
		if (Vector3.Distance (sunPosition, parentPosition) <= 30) {
			transform.position = new Vector3 (parentPosition.x - (sunPosition.x - parentPosition.x), parentPosition.y - (sunPosition.y - parentPosition.y), 0.5F);
			newAlpha = 1 - Vector3.Distance (sun_X, parent_X) / 30;
		} else {
			newAlpha = 0;
			this.collider.enabled = false;
		}

		originalColour = renderer.material.color;
		renderer.material.color = new Color (originalColour.r, originalColour.g, originalColour.b, newAlpha);
	}
}