using UnityEngine;
using System.Collections;
using System.Linq;

public class Model : SenderMono, IModel, IMainPageDelegate {
	
	string _value = "default";
	public string Value { 
		get{ return _value; }
		set{ 
			_value = value;
			OnValueChanged();
		}
	}
	
	void OnValueChanged(){
		Sender.Receivers.ToList ().ForEach (obj => {
			((IModelDelegate)obj).onValueChanged(this);
		});
	}

	public void OnPressX(object sender){
		Value = "x0";
	}

	public void OnPressY(object sender){
		Value = "y0";
	}
	
	protected override bool HandleVerifyReceiverDelegate (object receiver){
		return typeof(IModelDelegate).IsAssignableFrom (receiver.GetType ());
	}
}
