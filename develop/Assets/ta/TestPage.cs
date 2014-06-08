using UnityEngine;
using System.Collections;

public class TestPage : MonoBehaviour {

	public GameObject txt_showname;
	void onTouchConsumerEventMouseDown( string eventName ){
		txt_showname.GetComponent<TextMesh> ().text = eventName;
	}

	void onTouchConsumerEventMouseUp(){

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
