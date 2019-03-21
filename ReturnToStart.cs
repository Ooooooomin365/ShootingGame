using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToStart : MonoBehaviour {
	
	public GameObject Button; //Buttonオブジェクト
	
	public GameObject Text; //Buttonの中のテキスト（「スタート画面に戻る」のUI表示）
	
	//ゲーム開始時はボタン機能を消す
	void Start () {
		Button.GetComponent<Image>().enabled = false;
		Button.GetComponent<Button>().enabled = false;
		Text.GetComponent<Text>().enabled = false;
	}

	public void OnClick(){
		SceneManager.LoadScene("Title");
	}
	
	//ボタンを表示させるメソッド
	public void AppearButton(){
		Button.GetComponent<Image>().enabled = true;
		Button.GetComponent<Button>().enabled = true;
		Text.GetComponent<Text>().enabled = true;
	}
	
}
