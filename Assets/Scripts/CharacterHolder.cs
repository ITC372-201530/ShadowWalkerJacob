using UnityEngine;
using System.Collections;

public class CharacterHolder : MonoBehaviour {

	void OnTriggerEnter (Collider other){
		if (other.transform.tag.Equals ("Player"))
			other.transform.parent = gameObject.transform;
		else if (other.transform.tag.Equals ("Solid Object"))
			this.renderer.enabled = false;
	}

	void OnTriggerExit (Collider col){
		col.transform.parent = null;
	}

}
