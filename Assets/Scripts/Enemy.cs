using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float baseHP = 100f;
	float hp = 100f;
	public GameObject effectExplorer;
	public GameObject coin;
	bool bDie=false;
	
	void Start()
	{
		hp = baseHP;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(bDie) return;
		
		switch(other.tag)
		{
		case "Bullet":
			ApplyDamage(other.gameObject.GetComponent<Bullet>());
			break;
		case "BottomConllider":
			GameObject.Destroy(gameObject);
			break;
		}
	}
	
	void ApplyDamage(Bullet bullet)
	{
		float damage = bullet.damage;
		hp -= damage;
//		Debug.Log(hp+"/"+baseHP);
		CheckDie();
		if(!bDie)
			FixHpBar();
	}
	
	void CheckDie()
	{
		if(hp<=0)
		{
			bDie=true;
		
			Vector3 pos = transform.position;
			GameObject.Destroy(gameObject);
			
			// effect die
			GameObject explorer = Instantiate(effectExplorer,pos,Quaternion.identity) as GameObject;
			explorer.transform.parent = transform.parent;
			explorer.transform.localScale = new Vector3(0.5f,0.5f,1);
			
			// coin
			int nCoin = ((int)baseHP/100);
			for(;nCoin>=0;nCoin--)
			{
				GameObject iCoin = Instantiate(coin,pos,Quaternion.identity) as GameObject;
				iCoin.transform.parent = transform.parent;
				iCoin.transform.localScale = new Vector3(25,25,1);
			}
			
			/*
			UISprite sprite = explorer.GetComponent<UISprite>();
			if(sprite!=null)
				sprite.MakePixelPerfect();
			
			UISpriteAnimation ani = explorer.GetComponent<UISpriteAnimation>();
			if(ani!=null)
			{
				ani.namePrefix = "explorer1";
				ani.framesPerSecond = 5;
			}*/
		}
	}
	
	void FixHpBar()
	{
		int hpScale = (int)(hp/baseHP*46f);
		
		Transform hp_right = transform.FindChild("hp-right");
		if(hp_right != null)
			GameObject.Destroy(hp_right.gameObject);
		
		Transform hp_middle = transform.FindChild("hp-middle");
		if(hp_middle != null)
		{
			if(hpScale>5)
			{
				hp_middle.localScale = new Vector3(hpScale-5,7,1);
			}
			else
			{
				GameObject.Destroy(hp_middle.gameObject);
			}
		}
	}
}
