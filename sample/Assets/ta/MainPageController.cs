using UnityEngine;
using System.Collections;

public class MainPageController : MonoBehaviour {

	public GameObject gameName;

	void onTouchConsumerEventMouseDown(string eventName){
		gameName.GetComponent<TextMesh> ().text = eventName;
	}
	
	void onTouchConsumerEventMouseUp(string eventName){

	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
