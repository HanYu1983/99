using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class PlayPage : SenderMono {

	Dictionary<int, GameObject> _hands = new Dictionary<int, GameObject> ();
	GameObject _stack;
	public GameObject container_hand;
	public GameObject container_hand2;
	public GameObject container_hand3;
	public GameObject container_hand4;
	public GameObject container_stack;
	// Use this for initialization
	protected override void Start () {
		base.Start ();

		Sender.Receivers.ToList().ForEach( obj => {
			((IPlayPageDelegate)obj).onPlayPageGameStart( this );
		});
		//StartCoroutine (delayAndPlay ());
	}

	public void gameStart(){

	}

	public void dealCard( IDeck deck, IDeckPlayer player, ICard card  ){
		PrefabSource prefabSource = EntityManager.Singleton.GetEntity<PrefabSource> (100).Instance;
		if (_stack == null) {
			_stack = (GameObject)Instantiate (prefabSource.Stack, container_stack.transform.position, container_stack.transform.rotation);
			_stack.transform.parent = container_stack.transform;
		}
		_stack.GetComponent<StackView> ().dealCard (player, card);

		GameObject layer = null;
		if (!_hands.ContainsKey( player.EntityID )) {
			switch( player.EntityID ){
			case (int)EnumEntityID.Player1:layer = container_hand;break;
			case (int)EnumEntityID.Player2:layer = container_hand2;break;
			case (int)EnumEntityID.Player3:layer = container_hand3;break;
			case (int)EnumEntityID.Player4:layer = container_hand4;break;
			}

			GameObject handView = (GameObject)Instantiate (prefabSource.Hand, layer.transform.position, layer.transform.rotation);
			handView.transform.parent = layer.transform;
			_hands.Add( player.EntityID, handView );
		}
		_hands[ player.EntityID ].GetComponent<HandView> ().addCard (card);
	}

	public void addCard( IDeck deck, IDeckPlayer player, ICard card ){
		/*
		Debug.Log ("player.EntityID: " + player.EntityID);
		if (player.EntityID != 0) return;
		if (hand == null) {
			PrefabSource prefabSource = EntityManager.Singleton.GetEntity<PrefabSource> (100).Instance;
			hand = (GameObject)Instantiate (prefabSource.Hand, container_hand.transform.position, container_hand.transform.rotation);
			hand.transform.parent = this.transform;
		}
		hand.GetComponent<HandView> ().addCard (card);
*/
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