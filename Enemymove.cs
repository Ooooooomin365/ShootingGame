using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemymove : MonoBehaviour {
	
	private float speed = 0.8f; //敵機のスピード
	
	private GameObject Airplane; //プレイヤーの親オブジェクト
	
	private GameObject ClosetoEnemy; //ClosetoEnemyオブジェクト

	// Use this for initialization
	void Start () {
		Airplane = GameObject.Find("Airplaneparent");
		
		ClosetoEnemy = GameObject.Find("ClosetoEnemy");
	}
	
	// Update is called once per frame
	void Update () {
		if(speed != 0){
		
			// 敵はプレイヤーの方向へ飛んでくる
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(Airplane.transform.position.x, Airplane.transform.position.y + 90 ,Airplane.transform.position.z -100) , speed);
		}else{
			speed = 0;
			transform.Translate(0.0f, -0.1f, -0.1f); //下記のスレッドが呼び出されてspeed値が0になるとゆっくり前方下に墜落していく。
		}
	}
	
	//missileタグのついたもの（プレイヤーのミサイル）に衝突したとき
	void OnCollisionEnter(Collision collision){
		if(collision.collider.CompareTag("missile")){
			speed = 0;
			GetComponent<ParticleSystem>().Play();
			Destroy(gameObject, 1.5f);
			ClosetoEnemy.GetComponent<Text>().text = ""; //「近くに敵がいるぞ！」のUIが消える
		}
	}
			
}
