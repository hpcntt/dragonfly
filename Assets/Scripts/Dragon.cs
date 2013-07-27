using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour {
	public GameObject bullets;
	public GameObject explorer;
	
	float timeForFire=0.05f;
	float smooth = 6.0f;
	float bulletSpeed = 1000f;
	bool imDie=false;
	
	
	// Use this for initialization
	void Start () {
		Invoke("Fire",timeForFire);	
	}
	
	void Fire()
	{
		if(imDie) return;
		
		GameObject bullet = Instantiate(bullets,transform.localPosition,Quaternion.identity) as GameObject;
		bullet.transform.parent = transform.parent;
		bullet.gameObject.GetComponent<UISprite>().MakePixelPerfect();
		bullet.transform.position = transform.position;
		iTween.MoveTo(bullet.gameObject,iTween.Hash(
				"y",400,
				"speed",bulletSpeed,
				"islocal",true,
				"easetype",iTween.EaseType.linear
			)
		);
		
		
		Invoke("Fire",timeForFire);
	}
	
	
	void Update()
	{
		if(imDie) return;
		
		if( Input.GetMouseButton(0))
		{
			Vector3 mPos = Input.mousePosition;
			Vector3 wPos = Camera.mainCamera.ScreenToWorldPoint(mPos);
			wPos.y = transform.position.y;
			wPos.z = transform.position.z;
			
			transform.position = Vector3.Lerp (
	        	transform.position, wPos,
	        	Time.deltaTime * smooth);
		}
		
		if(Input.GetKeyDown(KeyCode.P))
	    {
	         Debug.Break();
	    }
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemy")
		{
			imDie = true;
			GameObject ex = Instantiate(explorer,transform.position,Quaternion.identity) as GameObject;
			ex.transform.parent = transform.parent;
			ex.transform.localScale = new Vector3(0.5f,0.5f,1);
			GameObject.Destroy(gameObject);
			Application.LoadLevel("Menu");
		}
		
		/*
		UISprite sprite = ex.transform.GetChild("explorer1").gameObject.GetComponent<UISprite>();
		if(sprite!=null)
			sprite.MakePixelPerfect();
		
		UISpriteAnimation ani = explorer.GetChild("explorer1").gameObject.GetComponent<UISpriteAnimation>();
		if(ani!=null)
		{
			ani.namePrefix = "explorer1";
			ani.framesPerSecond = 5;
		}
		*/
	}
	
	/*
	void Update()
	{
		Debug.Log(Input.touchCount);
		if (Input.touchCount > 0)
	    {
	        // Only work with the first touch
	        // and only if the touch moved since last update
			Debug.Log(Input.touches.Length);
	        if (Input.touches[0].phase == TouchPhase.Moved)
	        {
				
				Debug.Log("3");
	            float x = Input.touches[0].deltaPosition.x * speed * Time.deltaTime;
	            float y = Input.touches[0].deltaPosition.y * speed * Time.deltaTime;
	
	            transform.Translate(new Vector3(x, y, 0));
	        }
	    }
	}
	*/
}
