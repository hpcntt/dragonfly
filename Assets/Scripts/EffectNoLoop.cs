using UnityEngine;
using System.Collections;

public class EffectNoLoop : MonoBehaviour {
	
	void Update () {
		UISpriteAnimation ani = gameObject.GetComponent<UISpriteAnimation>();
		if(!ani.isPlaying)
		{
			GameObject.Destroy(gameObject);
		}
	}
}
