using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missilemove : MonoBehaviour {
	
	private float speed = 40; //ミサイルの速度
	
	private float distance; //敵機と自機の距離
	
	private GameObject Enemy; //Enemyタグの付いたオブジェクト
	
	private bool isTrue = false; //敵をロックオンした際にtrueとなる
	
	public GameObject Missile; //ミサイルプレハブ
	
	private GameObject HitMissile; //HitMissileオブジェクト（「ミサイル命中！」のUI表示）
	
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().AddForce(1200.0f, -150.0f, 200.0f); //ミサイルを発射時に少し右斜め下に動かしてから敵に向かうようにする（見栄えをよくするため）
		
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
		
		HitMissile = GameObject.Find("HitMissile");
		
		HitMissile.GetComponent<Text>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		Lockon();
		
		if(isTrue = true){
			transform.Translate(0,0,speed * Time.deltaTime);
		}
		
		Destroy(gameObject, 25.0f); //当たらなかったミサイルは25秒後に消えるように設定
		
	}
	
	//ミサイルは一定の時間ずつ加速していく
	void FixedUpdate(){
		if(speed == 0.0f){
			speed = 0;
		}else{
			speed = speed + 2.0f; //衝突後は速度0に、それ以外はスピードは加速させる。
		}
	}
	
	void OnCollisionEnter(Collision other){
	
		GetComponent<Rigidbody>().isKinematic = true; //衝突後はその場で爆発させる
		speed = 0; //ミサイル衝突後はミサイルの速度を0にする
		GetComponent<ParticleSystem>().Play();
		Destroy(gameObject, 2.5f); //爆発のエフェクト終了後にミサイルオブジェクトを消す
		
		if(other.gameObject.tag == "Enemy"){
		
			GetComponent<Rigidbody>().isKinematic = true; 
			speed = 0;
			GetComponent<ParticleSystem>().Play();
			HitMissile.GetComponent<Text>().enabled = true;
			Invoke("empty" , 2.0f); //敵に命中したときのみ「ミサイル命中」のUIを表示させる
			Destroy(gameObject, 2.5f); 
			
		}
		
	}
	
	//マウスカーソルからRayを出し、敵に当たるとロックオンとなる。
	private void Lockon(){
	
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
		
			if(hit.collider.gameObject.tag == "Enemy" || hit.collider.gameObject.tag == "Enemymissile"){
				
				//一定速度を超えたミサイルにはロックオン機能を作動させない（遠く外れたミサイルが再度ロックオン時に遠くから戻ってくることになり、非現実的だから）
				if(speed < 3000.0f){
				
					isTrue = true;
					Missile.transform.position = Vector3.MoveTowards(Missile.transform.position, hit.transform.position, speed * Time.deltaTime);
					transform.LookAt(hit.transform.position);
					
				}
				
			}else{
			
				isTrue = false;
				
			}
			
		}
		
	}
	
	//「ミサイル命中！」のUI表示
	private void empty(){
		HitMissile.GetComponent<Text>().enabled = false;
	}
}
