using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {
	
	public GameObject Missile; //プレイヤーのミサイルの親オブジェクト
	
	public GameObject Airplane; //プレイヤーの親オブジェクト

	//マウスクリックでミサイルプレハブ生成（プレイヤーの親オブジェクトと同様のtransform）
	public void Update(){
	
		if(Input.GetMouseButtonDown(0)){
		
			Instantiate(Missile, transform.position, transform.rotation);
			
		}
		
	}
	
}
