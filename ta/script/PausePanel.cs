using UnityEngine;
using System.Collections;

public class PausePanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTouchConsumerEventMouseDown( string en ){
		SendMessageUpwards( "closeTargetPage", "pausePanel" );
		switch (en) {
		case "btn_resume":break;
		case "btn_quit":
			SendMessageUpwards( "openTargetPage", "mainPage" );
			SendMessageUpwards( "closeTargetPage", "playPage" );break;
		}
	}
}
