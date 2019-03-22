using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject EnemyPrefab; //敵のプレハブ定義
	
	private float span; //敵が出る頻度
	
	private float delta = 0; //時間経過
	
	private Pointmaker pointmaker; //Pointmakerスクリプト
	
	public int point1; //画面左上のポイント
	
	public GameObject PointController; //ポイントコントローラオブジェクトの定義

	// Use this for initialization
	void Start () {
		
		pointmaker = PointController.GetComponent<Pointmaker>();
		
		point1 = pointmaker.point;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		point1 = pointmaker.point;
		
		if(point1 <= 150){
		
			firstround();
			
		}else if(point1 > 150 && point1 <= 270){
		
			secondround();
			
		}else if(point1 > 270 && point1 <= 400){
			
			thirdround();
		
		}else if(point1 > 400){
			
			fourthround();
		}
	}	
	
	//firstround～fourthroundメソッドは、ポイントの値によって敵の出現頻度を定義している
	private void firstround(){
		Debug.Log("1");
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
		Debug.Log("2");
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
		Debug.Log("3");
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
		Debug.Log("4");
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
