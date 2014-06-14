using UnityEngine;
using System.Collections;

public class SenderMono : ReceiverMono, IEventSender {
	DefaultEventSender _sender = new DefaultEventSender();
	public DefaultEventSender Sender {
		get{ return _sender; }
	}

	protected override void Start () {
		_sender.VerifyReceiverDelegate += HandleVerifyReceiverDelegate;
		base.Start (); // register after add Verify function
	}

	protected override void OnDestroy(){
		base.OnDestroy (); // unregister before delete Verify function
		_sender.VerifyReceiverDelegate -= HandleVerifyReceiverDelegate;
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
