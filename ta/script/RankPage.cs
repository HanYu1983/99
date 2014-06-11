using UnityEngine;
using System.Collections;

public class RankPage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTouchConsumerEventMouseDown( string en ){
		switch( en ){
		case "btn_quit":
			SendMessageUpwards( "openTargetPage", "mainPage" );
			SendMessageUpwards( "closeTargetPage", "rankPage" );break;
		}
	}
}
