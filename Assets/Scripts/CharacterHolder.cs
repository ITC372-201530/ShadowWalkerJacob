using UnityEngine;
using System.Collections;

public class CharacterHolder : MonoBehaviour {

	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag.Equals ("Player") || col.transform.tag.Equals ("Pushable"))
		col.transform.parent = gameObject.transform;
	}

	void OnTriggerExit (Collider col)
	{
		col.transform.parent = null;
	}

}
