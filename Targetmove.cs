using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Targetmove : MonoBehaviour {
	
	public GameObject LockonImage; //LockonImageオブジェクト（ロックオンの画像）
	
	// Update is called once per frame
	void Update () {
	
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
		
			if(hit.collider.gameObject.tag == "Enemy" || hit.collider.gameObject.tag == "Enemymissile"){ //敵、もしくは敵のミサイルにRayが衝突したときにロックオン画像を表示
			
				GetComponent<Image>().enabled = true;
				TargetLockon();
				Invoke("TargetLockonReset", 0.3f);
				
			}
			
		}
		
	}
	
	void TargetLockon(){
		transform.position = Input.mousePosition;
	}
	
	private void TargetLockonReset(){
		GetComponent<Image>().enabled = false;
	}
	
}
