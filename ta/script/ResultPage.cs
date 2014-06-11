using UnityEngine;
using System.Collections;

public class ResultPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTouchConsumerEventMouseDown( string en ){
		SendMessageUpwards( "closeTargetPage", "resultPage" );
		switch (en) {
		case "btn_replay":
			SendMessageUpwards( "openTargetPage", "playPage" );break;
		case "btn_rank":
			SendMessageUpwards( "openTargetPage", "rankPage" );break;
		case "btn_quit":
			SendMessageUpwards( "openTargetPage", "mainPage" );break;
		}
	}
}
