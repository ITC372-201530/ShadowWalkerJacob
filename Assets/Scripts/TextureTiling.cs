using UnityEngine;
using System.Collections;

public class TextureTiling : MonoBehaviour {

	void OnDrawGizmos () {
		this.gameObject.renderer.sharedMaterial.SetTextureScale("_MainTex",new Vector2(this.gameObject.transform.lossyScale.x,this.gameObject.transform.lossyScale.y))  ;
	}

}
