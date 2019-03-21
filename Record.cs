using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Record : MonoBehaviour {
	
	public GameObject PointController;
	
	private Pointmaker pointmaker;

	// Use this for initialization
	void Start () {
		pointmaker = PointController.GetComponent<Pointmaker>();
	}
	
	public void destroy(){
		if(pointmaker.point <= 120){
			GetComponent<Text>().text = "あなたは一等兵レベルです";
		}else if(pointmaker.point > 120 && pointmaker.point <= 250){
			GetComponent<Text>().text = "あなたは中尉レベルです";
		}else if(pointmaker.point > 250 && pointmaker.point <= 400){
			GetComponent<Text>().text = "あなたは大佐レベルです";
		}else{
			GetComponent<Text>().text = "あなたは神の腕前です";
		}
	}
}
