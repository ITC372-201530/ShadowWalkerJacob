using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {




	void onClick(){
		Application.LoadLevel ("Level01");
		print ("Clicked");
	}
}
