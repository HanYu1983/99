using UnityEngine;
using System.Collections;
using System.Linq;
public class PlayPage : SenderMono {
	
	// Use this for initialization
	protected override void Start () {
		base.Start ();
		StartCoroutine (delayAndPlay ());
	}

	IEnumerator delayAndPlay(){
		yield return new WaitForSeconds (3);
		Sender.Receivers.ToList().ForEach( obj => {
			((IPlayPageDelegate)obj).onPlayPageBtnEnterClick( this );
		});
	}
	
	// Update is called once per frame
	void Update () {

	}

	void onTouchConsumerEventMouseDown( string en ){
		switch (en) {
		case "btn_pause":
			Debug.Log ( "onTouchConsumerEventMouseDown" );
			Sender.Receivers.ToList().ForEach( obj => {
				((IPlayPageDelegate)obj).onPlayPageBtnPauseClick( this );
			});
			break;
		}
	}

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		return typeof(IPlayPageDelegate).IsAssignableFrom (receiver.GetType ());
	}
}