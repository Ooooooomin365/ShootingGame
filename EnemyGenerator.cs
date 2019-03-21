using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject EnemyPrefab; //敵のプレハブ定義
	
	private float span; //敵が出る頻度
	
	private float delta = 0; //時間経過
	
	public int point; //画面左上のポイント
	
	public GameObject PointController; //ポイントコントローラオブジェクトの定義

	// Use this for initialization
	void Start () {
		point = PointController.GetComponent<Pointmaker>().point;
	}
	
	// Update is called once per frame
	void Update () {
		if(point <= 150){
		
			firstround();
			
		}else if(point > 150 && point <= 270){
		
			secondround();
			
		}else if(point > 270 && point <= 400){
			
			thirdround();
		
		}else if(point > 400){
			
			fourthround();
		}
	}	
	
	//firstround～fourthroundメソッドは、ポイントの値によって敵の出現頻度を定義している
	private void firstround(){
		span = 6.0f;
		this.delta += Time.deltaTime;
		if(this.delta > this.span){
			this.delta = 0;
			GameObject enemy = Instantiate(EnemyPrefab) as GameObject;
				
			int px = Random.Range(0, 4000); // プレハブの出るX座標。yとzも同様。
			int py = Random.Range(140, 200);
			int pz = Random.Range(3000, 4000);
				
			enemy.transform.position = new Vector3(px, py, pz);
		}
	}
	
	private void secondround(){
		span = 4.0f;
		this.delta += Time.deltaTime;
		if(this.delta > this.span){
			this.delta = 0;
			GameObject enemy = Instantiate(EnemyPrefab) as GameObject;
				
			int px = Random.Range(0, 4000); // プレハブの出るX座標。yとzも同様。
			int py = Random.Range(140, 200);
			int pz = Random.Range(3000, 4000);
				
			enemy.transform.position = new Vector3(px, py, pz);
		}
	}
	
	private void thirdround(){
		span = 2.0f;
		this.delta += Time.deltaTime;
		if(this.delta > this.span){
			this.delta = 0;
			GameObject enemy = Instantiate(EnemyPrefab) as GameObject;
				
			int px = Random.Range(0, 4000); // プレハブの出るX座標。yとzも同様。
			int py = Random.Range(140, 200);
			int pz = Random.Range(3000, 4000);
				
			enemy.transform.position = new Vector3(px, py, pz);
		}
	}
	
	private void fourthround(){
		span = 1.0f;
		this.delta += Time.deltaTime;
		if(this.delta > this.span){
			this.delta = 0;
			GameObject enemy = Instantiate(EnemyPrefab) as GameObject;
				
			int px = Random.Range(0, 4000); // プレハブの出るX座標。yとzも同様。
			int py = Random.Range(140, 200);
			int pz = Random.Range(3000, 4000);
				
			enemy.transform.position = new Vector3(px, py, pz);
		}
	}
}
