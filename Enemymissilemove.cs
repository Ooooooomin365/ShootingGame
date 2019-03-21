using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemymissilemove : MonoBehaviour {

	private GameObject Airplane; //プレイヤーの親オブジェクト
	
	public GameObject Enemy; //敵機の親オブジェクト
	
	public GameObject EnemymissilePrefab; //敵ミサイルのプレハブ
	
	private float delta = 0;
	
	private float span = 6.0f; //敵ミサイルの頻度
	
	private float distance; //敵機とプレイヤーの距離
	
	private GameObject ClosetoEnemy; //ClosetoEnemyオブジェクト

	// Use this for initialization
	void Start () {
		Airplane = GameObject.Find("Airplaneparent");
		
		ClosetoEnemy = GameObject.Find("ClosetoEnemy");
	}
	
	// Update is called once per frame
	void Update () {
		Enemyattack();
	}
	
	public void Enemyattack(){
		distance = Vector3.Distance(Enemy.transform.position, Airplane.transform.position);
		
		//距離が300.0以下に縮まったら敵がミサイルを撃ってくる。
		if(distance <= 300.0f){
			ClosetoEnemy.GetComponent<Text>().text = "近くに敵がいるぞ！"; 
			this.delta += Time.deltaTime;
			if(this.delta > this.span){
				this.delta = 0;
				GameObject missile = Instantiate(EnemymissilePrefab) as GameObject;
				
				float px = Enemy.transform.position.x;
				float py = Enemy.transform.position.y-10; //敵の少し下からミサイルが出るようにしている。少しずらさないと敵オブジェクトと敵ミサイルが衝突検知してしまうから。
				float pz = Enemy.transform.position.z;
				
				missile.transform.position = new Vector3(px, py, pz);
			}
		}
	}
}
