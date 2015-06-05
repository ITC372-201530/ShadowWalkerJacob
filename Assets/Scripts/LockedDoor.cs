using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {

	public AudioSource Source;

	void Start() {
		Source = GetComponent<AudioSource>();

	}

	void OnDisable() {
		Source.enabled = true;
		Source.Play ();
	}
}
