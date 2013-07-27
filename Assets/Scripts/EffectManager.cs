using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {
	public GameObject effects;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void CreateEffect(string effectNamePrefix, Vector3 position)
	{
		GameObject eff = Instantiate(effects,position,Quaternion.identity) as GameObject;
		UISpriteAnimation ani = eff.GetComponent<UISpriteAnimation>();
		ani.namePrefix = effectNamePrefix;
	}
}
