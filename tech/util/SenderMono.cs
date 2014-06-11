using UnityEngine;
using System.Collections;

public class SenderMono : ReceiverMono, IEventSender {
	DefaultEventSender _sender = new DefaultEventSender();
	public DefaultEventSender Sender {
		get{ return _sender; }
	}

	protected override void Start () {
		base.Start ();
		_sender.VerifyReceiverDelegate += HandleVerifyReceiverDelegate;
		EventManager.Singleton.AddSender (this);
	}

	protected override void OnDestroy(){
		EventManager.Singleton.RemoveSender (this);
		base.OnDestroy ();
	}

	protected virtual bool HandleVerifyReceiverDelegate (object receiver){
		return false;
	}

	public void OnAddReceiver(object receiver){
		_sender.OnAddReceiver (receiver);	
	}
	
	public void OnRemoveReceiver(object receiver){
		_sender.OnRemoveReceiver (receiver);
	}
}
