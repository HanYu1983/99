using UnityEngine;
using System.Collections;

public class MainPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTouchConsumerEventMouseDown( string en ){
		SendMessageUpwards( "closeTargetPage", "mainPage" );
		switch (en) {
			case "btn_start":
			SendMessageUpwards( "openTargetPage", "playPage" );break;
			case "btn_rank":
			SendMessageUpwards( "openTargetPage", "rankPage" );break;
			case "btn_quit":break;
		}
	}

	void onTouchConsumerEventMouseUp(){

	}
}
