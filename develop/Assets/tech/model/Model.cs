using UnityEngine;
using System.Collections;
using System.Linq;

public class Model : MonoBehaviour, IModel, IMainPageDelegate, IEventSender {

	DefaultEventSender _sender = new DefaultEventSender();

	void Start(){
		_sender.VerifyReceiverDelegate += HandleVerifyReceiverDelegate;
		EventManager.Singleton.AddSender (this);
		EventManager.Singleton.AddReceiver (this);
	}

	void OnDestroy(){
		EventManager.Singleton.RemoveReceiver (this);
		EventManager.Singleton.RemoveSender (this);
	}
	
	string _value = "default";
	public string Value { 
		get{ return _value; }
		set{ 
			_value = value;
			OnValueChanged();
		}
	}
	
	void OnValueChanged(){
		_sender.Receivers.ToList ().ForEach (obj => {
			((IModelDelegate)obj).onValueChanged(this);
		});
	}

	public void OnPressX(object sender){
		Value = "x0";
	}

	public void OnPressY(object sender){
		Value = "y0";
	}

	public void OnAddReceiver(object receiver){
		_sender.OnAddReceiver (receiver);	
	}
	
	public void OnRemoveReceiver(object receiver){
		_sender.OnRemoveReceiver (receiver);
	}
	
	bool HandleVerifyReceiverDelegate (object receiver){
		return typeof(IModelDelegate).IsAssignableFrom (receiver.GetType ());
	}
}
