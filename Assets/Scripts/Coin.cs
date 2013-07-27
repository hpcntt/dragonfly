using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	float speed = 100f;
	// Use this for initialization
	/*
	void Start () {
		Vector3[] path = iTweenPath.GetPath("CoinDropDown");
		path[0] = transform.position;
		path[1] = new Vector3(path[0].x+0.1f,path[0].y+0.2f,-1);
		path[2] = new Vector3(path[1].x+0.2f,path[2].y,-1);
		
		if(Mathf.Abs(path[2].x)>160)
		{
			path[1].x = 2*path[0].x - path[1].x;
			path[2].x = 2*path[0].x - path[2].x;
		}
	
		iTween.MoveTo(gameObject,iTween.Hash(
				"path",path,
				"speed",2f,
				"easetype",iTween.EaseType.easeInQuint
			)
		);
	}
	*/
	int delta;
	int a;
	void Start()
	{
		delta = Random.Range(20,50);
		a=Random.Range(0,2)*2-1;
		Vector3 nextPosition = new Vector3(transform.localPosition.x+a*delta, transform.localPosition.y+delta*1.5f,transform.localPosition.z);
		if(nextPosition.x>160) nextPosition.x=160;
		if(nextPosition.x<-160) nextPosition.x=-160;
		
		iTween.MoveTo(gameObject,iTween.Hash(
				"x",nextPosition.x,
				"y",nextPosition.y,
				"speed",speed,
				"islocal",true,
				"easetype",iTween.EaseType.easeOutSine,
				"oncomplete","DropCoin"
			)
		);
	}
	
	void DropCoin()
	{
		float x = transform.localPosition.x+a*delta;
		if(x>160) x=160;
		if(x<-160) x=-160;
		iTween.MoveTo(gameObject,iTween.Hash(
				"x",x,
				"y",-300f,
				"speed",speed*3,
				"islocal",true,
				"easetype",iTween.EaseType.easeInSine
			)
		);
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(transform.localPosition.x) > 160)
		{
			iTween it = gameObject.GetComponent<iTween>();
			if(it!=null)
			{
				
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		switch(other.tag)
		{
		case "BottomConllider":
			Debug.Log("GameObject.Destroy("+gameObject.name+";");
			GameObject.Destroy(gameObject);
			break;
		}
	}
	
	/*
	void FixedUpdate()
	{
		Debug.Log("f update");
	  	Vector3 curVel = rigidbody.velocity;
	  	curVel.y -= myGravity * Time.deltaTime; // apply fake gravity
	  	rigidbody.velocity = curVel;
	}
	*/
}
