using UnityEngine;
using System.Collections;

public class SenderAdapter : ReceiverAdatper, IEventSender
{
	DefaultEventSender _sender = new DefaultEventSender();
	public DefaultEventSender Sender {
		get{ return _sender; }
	}
	
	protected SenderAdapter () {
		_sender.VerifyReceiverDelegate += HandleVerifyReceiverDelegate;
		EventManager.Singleton.AddSender (this);
	}
	
	~SenderAdapter(){
		EventManager.Singleton.RemoveSender (this);
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

