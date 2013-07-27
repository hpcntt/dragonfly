using UnityEngine;
using System.Collections;

public class StreetLoop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetMoving();
	}
	
	void SetMoving()
	{
		iTween.Stop(gameObject);
		iTween.MoveTo(gameObject, iTween.Hash(
				"speed",80f,
				"islocal",true,
				"easetype",iTween.EaseType.linear,
				"y",-390f,
				"oncomplete","ResetPosition",
				"oncompletetarget",gameObject
			)
		);
	}
	
	void ResetPosition()
	{
		//Debug.Log(gameObject.name+ ":"+transform.localPosition.ToString());
		transform.localPosition = new Vector3(0,500f,0);
		SetMoving();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
