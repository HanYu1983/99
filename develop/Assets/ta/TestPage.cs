using UnityEngine;
using System.Collections;
using System.Linq;

public class TestPage : MonoBehaviour, IModelDelegate, IEventSender {

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

	public GameObject txt_showname;
	void onTouchConsumerEventMouseDown( string eventName ){
		switch ( eventName ){
			case "btn_x":
			_sender.Receivers.ToList ().ForEach (obj => {
				((IMainPageDelegate)obj).OnPressX(this);
			});
			break;
			case "btn_y":
			_sender.Receivers.ToList ().ForEach (obj => {
				((IMainPageDelegate)obj).OnPressY(this);
			});
			break;
		}

		//txt_showname.GetComponent<TextMesh> ().text = eventName;
	}

	void onTouchConsumerEventMouseUp(){

	}

	public void onValueChanged(IModel sender){
		Debug.Log ("onValueChanged");
		txt_showname.GetComponent<TextMesh> ().text = sender.Value;
	}

	public void OnAddReceiver(object receiver){
		_sender.OnAddReceiver (receiver);	
	}
	
	public void OnRemoveReceiver(object receiver){
		_sender.OnRemoveReceiver (receiver);
	}

	bool HandleVerifyReceiverDelegate (object receiver){
		return typeof(IMainPageDelegate).IsAssignableFrom (receiver.GetType ());
	}
}
