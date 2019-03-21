using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointmaker : MonoBehaviour {
	
	public GameObject Point; //Pointオブジェクト
	
	private GameObject missile; //ミサイルプレハブ
	
	public int point = 0; //ゲーム開始時のPointは0にする
	
	private GameObject Enemy; //敵の親オブジェクト
	
	private float delta = 0; //時間経過
	
	
	// Use this for initialization
	void Start () {
	
		missile = GameObject.Find("Missileparent");
		Enemy = GameObject.Find("Enemyparent");
		
	}
	
	// Update is called once per frame
	void Update () {
	
		this.delta += Time.deltaTime;
		
		//7.0毎にポイントを加算していく
		if(this.delta > 7.0f){
		
			this.delta = 0;
			point += 10;
			
		}
		
		this.Point.GetComponent<Text>().text = "Point:" + this.point.ToString();
		
	}
	
}
