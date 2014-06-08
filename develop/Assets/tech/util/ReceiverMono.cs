using UnityEngine;
using System.Collections;

public class ReceiverMono : MonoBehaviour {
	protected virtual void Start(){
		EventManager.Singleton.AddReceiver (this);
	}
	
	protected virtual void OnDestroy(){
		EventManager.Singleton.RemoveReceiver (this);
	}
}
