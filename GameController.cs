using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	private GameObject Airplane; //プレイヤーオブジェクト
	
	private GameObject AirplaneEffect2; //AirplaneEffect2オブジェクト（スピードアップ時のパーティクルを設定したオブジェクト）
	
	private GameObject Energy; //Energyオブジェクト（スピードアップの制限時間を表すUI）
	
	public Record record; //Recordスクリプト
	
	private GameObject record1; //record1オブジェクト
	
	private float count = 0; //プレイヤーが地面下（y座標0以下）に入ると行われるカウント
	
	private GameObject Caution; //Cautionオブジェクト
	
	public GameObject Button; //「スタートに戻る」ボタンオブジェクト
	
	public ReturnToStart rs; //ReturnToStartスクリプト
	
	public GameObject Maincamera; //MainCameraオブジェクト
	
	public Music ms; //Musicスクリプト

	// Use this for initialization
	void Start () {
		Airplane = GameObject.Find("Airplane");
		
		AirplaneEffect2 = GameObject.Find("AirplaneEffect2");
		
		Energy = GameObject.Find("Energy"); 
		
		record1 = GameObject.Find("record1");
		
		record = record1.GetComponent<Record>();
		
		Caution = GameObject.Find("Caution");
		
		Caution.GetComponent<Text>().enabled = false;
		
		Button = GameObject.Find("Button");
		
		rs = Button.GetComponent<ReturnToStart>();
		
		ms = Maincamera.GetComponent<Music>();
	}
	
	// Update is called once per frame
	void Update () {
		
		direction2();
		
		EnergyController();
		
		if(Input.GetKey(KeyCode.Space)){
			SpeedUp();
		}else{
			Goahead();
			AirplaneEffect2.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
		}
		
		caution1();
	}
	
	//Dキーで右旋回、Aキーで左旋回、Wキーで上方向、Sキーで下方向へ
	private void direction2(){
		
		if(Input.GetKey(KeyCode.D)){
		
			transform.Rotate(0, 2, 0);
			Airplane.transform.Rotate(0, 0, -2); //プレイヤーの機体自体も回るように子オブジェクトも回転させる（これがないと空の親オブジェクトのみ回ることになり、機体は動かない）
			
		}else if(Input.GetKey(KeyCode.A)){
		
			transform.Rotate(0, -2, 0);
			Airplane.transform.Rotate(0, 0, 2); //子オブジェクトも回転させるため
			
		}else if(Input.GetKey(KeyCode.W)){
		
			transform.Translate(0, 3, 0);
			transform.Rotate(-2, 0, 0);
			Airplane.transform.Rotate(-2, 0, 0);
			
		}else if(Input.GetKey(KeyCode.S)){
		
			transform.Translate(0, -2, 0);
			transform.Rotate(2, 0, 0);
			Airplane.transform.Rotate(2, 0, 0);
			
		}else{
			
			//上記のif文で子オブジェクトも回転するようにしたが、上記だけだと機体が常には前を向かない。よってelse文で調整
			var local = Airplane.transform.localEulerAngles; //親オブジェクトと独立して考えないといけないため、Localで設定。
				local.z = 0;
				local.x = 0;
				local.y = 0;
				Airplane.transform.localEulerAngles = local; //x,y,z座標を0にすることで、方向転換しても子オブジェクトは最終的に必ず前を向く。
				
		}
	}
	
	//前進する
	private void Goahead(){
		transform.position += transform.forward * 0.6f;
	}
	
	//スピードアップ
	private void SpeedUp(){
		if(Energy.GetComponent<Image>().fillAmount > 0){
			AirplaneEffect2.GetComponent<ParticleSystem>().Play(true);
			transform.position += transform.forward * 1.8f;
		}
	}
	
	//Energy値の消費と回復スピード
	private void EnergyController(){
		if(Input.GetKey(KeyCode.Space)){
			Energy.GetComponent<Image>().fillAmount -= 0.005f;
		}else{
			Energy.GetComponent<Image>().fillAmount += 0.003f;
		}
	}
	
	//プレイヤーが地面下（y座標0以下）に入った際の警告
	private void caution1(){
	
		if(transform.position.y < 0){
		
			count += Time.deltaTime;
			Caution.GetComponent<Text>().enabled = true;
			
			if(count > 5.0){
			
				this.GetComponent<ParticleSystem>().Play(true);
				Invoke("Appearrecord", 2.0f);
				Invoke("returnToStart", 2.0f);
				Invoke("Appearmusic", 2.0f);
				Destroy(Airplane, 2.5f);
				
			}
		
		//プレイヤーが地上に戻るとcountを0に初期化し、警告文を消す
		}else{
		
			count = 0;
			Caution.GetComponent<Text>().enabled = false;
			
		}
		
	}
	
	//ReturnToStartスクリプトからのメソッド呼び出し
	private void returnToStart(){
		rs.AppearButton();
	}
	
	//Recordスクリプトからのメソッド呼び出し
	private void Appearrecord(){
		record.destroy();
	}
	
	//Musicスクリプトからのメソッド呼び出し
	private void Appearmusic(){
		ms.musicappear();
	}
}
