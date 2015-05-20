using UnityEngine;
using System.Collections;

public class KeepOnLoad : MonoBehaviour {

	private static KeepOnLoad instance;

	// Use this for initialization
	void Start(){	
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		if (instance != this)
			Destroy (gameObject);				
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
