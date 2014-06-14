using UnityEngine;
using System.Collections;

public class ReceiverAdatper
{
	protected ReceiverAdatper(){
		EventManager.Singleton.AddReceiver (this);
	}
	
	~ReceiverAdatper(){
		EventManager.Singleton.RemoveReceiver (this);
	}
}

