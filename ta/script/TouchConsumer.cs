using UnityEngine;
using System.Collections;

public class TouchConsumer : MonoBehaviour {

	void onMouseDown(){
		Debug.Log( transform.name );
		SendMessageUpwards ("onTouchConsumerEventMouseDown", transform.name,SendMessageOptions.DontRequireReceiver);
	}
	
	void onMouseUp(){
		SendMessageUpwards ("onTouchConsumerEventMouseUp", transform.name,SendMessageOptions.DontRequireReceiver);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
