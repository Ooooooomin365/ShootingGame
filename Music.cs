using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	
	private AudioSource[] ms; //AudioSourceの設定

	// Use this for initialization
	void Start () {
	
		ms = gameObject.GetComponents<AudioSource>();
		
	}
	
	//ゲーム終了時にBGMを変更するメソッド
	public void musicappear(){
	
		ms[0].Stop();
		ms[1].Play();
		
	}
	
}
