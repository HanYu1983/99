using UnityEngine;
using System.Collections;

public class TouchConsumer : MonoBehaviour {

	public string eventName;

	void onMouseDown(){
		SendMessageUpwards ("onTouchConsumerEventMouseDown", eventName,SendMessageOptions.DontRequireReceiver);
	}
	
	void onMouseUp(){
		SendMessageUpwards ("onTouchConsumerEventMouseUp", eventName,SendMessageOptions.DontRequireReceiver);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
