using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemymissileController : MonoBehaviour {
	
	public GameObject missile; //敵ミサイルのプレハブ定義
	
	private GameObject Airplane; //操作する戦闘機
	
	private GameObject Airplaneparent; //操作する戦闘機の親オブジェクト
	
	private float distance; //敵機と自機の距離
	
	public Record record; //Recordスクリプトの定義
	
	private GameObject record1; //record1オブジェクト
	
	public GameObject Button; //「スタートに戻る」ボタンのオブジェクト
	
	public ReturnToStart rs; // ReturnToStartスクリプトの定義
	
	public GameObject camera; //Main Cameraオブジェクトの定義
	
	public Music ms; //Musicスクリプトの定義

	// Use this for initialization
	void Start () {
		Airplane = GameObject.Find("Airplane");
		
		Airplaneparent = GameObject.Find("Airplaneparent");
		
		record1 = GameObject.Find("record1");
		
		record = record1.GetComponent<Record>();
		
		Button = GameObject.Find("Button");
		
		rs = Button.GetComponent<ReturnToStart>();
		
		camera = GameObject.Find("Main Camera");
		
		ms = camera.GetComponent<Music>();
	}
	
	// Update is called once per frame
	void Update () {
		
		collisionappear();

		transform.position = Vector3.MoveTowards(transform.position, Airplane.transform.position, 1.2f); //1.2の速さで敵のミサイルがプレイヤーに飛んでくる
		
		transform.LookAt(Airplane.transform.position);
	}
	
	void OnCollisionEnter(Collision collision){ 
		
		//地面や山など、プレイヤー以外にミサイルが衝突したときはその場で爆発→プレハブは2.5秒後に消滅
		GetComponent<EnemymissileController>().enabled = false; //衝突後はミサイルを止めたいのでスクリプトを消す。
		GetComponent<ParticleSystem>().Play();
		Destroy(gameObject, 2.5f); 
		
		//プレイヤーに衝突したとき
		if(collision.collider.CompareTag("Player")){
			GetComponent<EnemymissileController>().enabled = false;
			GetComponent<ParticleSystem>().Play();
			Destroy(gameObject, 2.5f);
			
			Airplaneparent.GetComponent<ParticleSystem>().Play(); //プレイヤーの親オブジェクトにある煙のパーティクルを呼び出す
			Invoke("returnToStart", 2.0f); //自機が消滅後、2秒遅らせてメソッド呼び出し
			Invoke("appearrecord", 2.0f);
			Invoke("Appearmusic", 2.0f);
			Destroy(Airplane, 2.5f);
		}
	}
	
	private void collisionappear(){
		distance = Vector3.Distance(missile.transform.position, Airplane.transform.position);
		
		if(distance <= 1.0f){
			Airplaneparent.GetComponent<Collider>().enabled = true; //敵ミサイルとの距離が1.0を下回ったらcapsule colliderを発動。常に発動させていると、プレイヤーがミサイルを撃った時にその場で衝突を検知し、爆発してしまう
		}
	}
	
	//Recordスクリプトからのメソッド呼び出し（「あなたは〇〇レベルです」のUI出現）
	private void appearrecord(){
		record.destroy();
	}
	
	//ReturnToStartスクリプトからのメソッド呼び出し（ボタン出現）
	private void returnToStart(){
		rs.AppearButton();
	}
	
	private void Appearmusic(){
		ms.musicappear();
	}
}
