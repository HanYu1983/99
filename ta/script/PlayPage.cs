using UnityEngine;
using System.Collections;

public class PlayPage : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		StartCoroutine (delayAndPlay ());
	}

	IEnumerator delayAndPlay(){
		yield return new WaitForSeconds (3);
		SendMessageUpwards ("closeTargetPage", "playPage");
		SendMessageUpwards ("openTargetPage", "resultPage");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void onTouchConsumerEventMouseDown( string en ){
		switch (en) {
		case "btn_pause":
			SendMessageUpwards( "openTargetPage", "pausePanel" );break;
		}
	}
}
