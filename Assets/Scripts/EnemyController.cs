using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public GameObject enemys;
	public Transform panel;
	int[]hp={
		0,100,200
	};
	
	
	// Use this for initialization
	void Start () {
		Invoke("CreateNewEnemy",Random.Range(2,5));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
		
	void CreateNewEnemy()
	{
		int nEnemy = Random.Range(3,6);
		for(int i=0; i<nEnemy; i++)
		{
			int index= Random.Range(0,2) == 0 ? i : 4-i;
			int enemyId = Random.Range(1,3);
			Vector3 pos = GlobarVar.initEnemyPos[index];
			GameObject enemy = Instantiate(enemys,pos,Quaternion.identity) as GameObject;
			enemy.transform.parent = panel;
			enemy.transform.localScale = Vector3.one;
			enemy.transform.localPosition = pos;
			
			enemy.transform.FindChild("enemysprite").gameObject.GetComponent<UISprite>().spriteName = "enemy"+enemyId+"-1";
			enemy.gameObject.GetComponent<Enemy>().baseHP=hp[enemyId];
			
			iTween.MoveTo(enemy,iTween.Hash(
					"speed",130f,
					"y",-400,
					"islocal",true,
					"easetype",iTween.EaseType.linear
				)
			);
		}
		Invoke("CreateNewEnemy",Random.Range(2,5));
	}
}
