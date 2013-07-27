using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public	float damage = 40;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		switch(other.tag)
		{
		case "Enemy":
		case "TopConllider":
			GameObject.Destroy(gameObject);
			break;
		}
	}
}
