using UnityEngine;
using System.Collections;
using System.Linq;
public class PlayPage : SenderMono {

	GameObject hand;
	public GameObject container_hand;
	// Use this for initialization
	protected override void Start () {
		base.Start ();

		PrefabSource prefabSource = EntityManager.Singleton.GetEntity<PrefabSource> (100).Instance;
		hand = (GameObject)Instantiate (prefabSource.Hand, container_hand.transform.position, container_hand.transform.rotation);
		hand.transform.parent = this.transform;

		//StartCoroutine (delayAndPlay ());
	}
	/*
	IEnumerator delayAndPlay(){
		yield return new WaitForSeconds (3);
		Sender.Receivers.ToList().ForEach( obj => {
			((IPlayPageDelegate)obj).onPlayPageBtnEnterClick( this );
		});
	}
	*/
	// Update is called once per frame
	void Update () {

	}

	void onTouchConsumerEventMouseDown( string en ){
		switch (en) {
		case "btn_pause":
			Sender.Receivers.ToList().ForEach( obj => {
				((IPlayPageDelegate)obj).onPlayPageBtnPauseClick( this );
			});
			break;
		}
	}

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		return receiver is IPlayPageDelegate;
	}
}