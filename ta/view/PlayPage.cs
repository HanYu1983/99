using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class PlayPage : SenderMono {

	Dictionary<int, GameObject> _hands = new Dictionary<int, GameObject> ();
	GameObject _stack;
	GameObject _table;

	public GameObject container_hand;
	public GameObject container_hand2;
	public GameObject container_hand3;
	public GameObject container_hand4;
	public GameObject container_stack;
	public GameObject container_table;

	private bool _onCardDown = false;
	private Vector3 _oldCardPosition;
	private Transform _cardTransform;

	// Use this for initialization
	protected override void Start () {
		base.Start ();

		Sender.Receivers.ToList().ForEach( obj => {
			((IPlayPageDelegate)obj).onPlayPageGameStart( this );
		});
		//StartCoroutine (delayAndPlay ());
	}

	//發牌給玩家
	public void DealCard( IDeck deck, IDeckPlayer player, ICard card  ){
		PrefabSource prefabSource = EntityManager.Singleton.GetEntity<PrefabSource> ((int)EnumEntityID.PrefabeSource).Instance;
		if (_stack == null) {
			_stack = (GameObject)Instantiate (prefabSource.Stack, container_stack.transform.position, container_stack.transform.rotation);
			_stack.transform.parent = container_stack.transform;
		}
		_stack.GetComponent<StackView> ().dealCard (player, card);
		AddCard (deck, player, card);
	}

	//玩家抽一張卡
	public void AddCard( IDeck deck, IDeckPlayer player, ICard card ){
		PrefabSource prefabSource = EntityManager.Singleton.GetEntity<PrefabSource> ((int)EnumEntityID.PrefabeSource).Instance;
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

	//把牌丟到牌堆上
	public void PushCardToTable( IDeck deck, IDeckPlayer player, ICard card ){
		if (_table == null) {
			PrefabSource prefabSource = EntityManager.Singleton.GetEntity<PrefabSource> ((int)EnumEntityID.PrefabeSource).Instance;
			_table = (GameObject)Instantiate( prefabSource.Table, container_table.transform.position, container_table.transform.rotation );
			_table.transform.parent = container_table.transform;
		}
		_table.GetComponent<TableView> ().PushCardToTable (deck, player, card);
		SendCard (player.EntityID, _hands[ player.EntityID ].GetComponent<HandView> ().getCardViewByModel (card));
	}

	// Update is called once per frame
	void Update () {
		if (_onCardDown && _cardTransform ) {
			Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 op = _cardTransform.position;
			Vector3 tp = ( mp - op ) * .2f;
			op += tp;
			op.z = _cardTransform.position.z;
			_cardTransform.position = op;
		}
	}

	void onTouchConsumerEventMouseDown( TouchEvent te ){
		Debug.Log (te.name);
		switch (te.name) {
		case "btn_pause":
			Sender.Receivers.ToList().ForEach( obj => {
				((IPlayPageDelegate)obj).onPlayPageBtnPauseClick( this );
			});
			break;
		case "CardView":
			_onCardDown = true;
			_cardTransform = te.target;
			_oldCardPosition = _cardTransform.position;
			break;
		}
	}

	void onTouchConsumerEventMouseUp( TouchEvent te ){
		Vector3 mp = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		Debug.Log (mp);
		if (mp.y > 0)	SendCard ( (int)EnumEntityID.Player1 ,_cardTransform.gameObject);
		else ReturnCard();

		_onCardDown = false;
		_cardTransform = null;
	}

	//玩家使用一張牌
	void SendCard( int playerId, GameObject cardView ){
		iTween.ScaleTo (cardView, iTween.Hash (	"x", 0,
		                                        "y", 0,
		                                        "time", 1,
		                                       	"oncomplete","onSendCardAniComplete",
		                                       	"oncompletetarget", this.gameObject,
		                                       	"oncompleteparams", cardView));
		_hands[ playerId ].GetComponent<HandView> ().subCard (cardView);
	}

	//玩家不使用牌，牌退回來的動畫
	void ReturnCard(){
		if (_cardTransform == null )	return;
		iTween.MoveTo (_cardTransform.gameObject, iTween.Hash (	"x", _oldCardPosition.x,
		                                                        "y", _oldCardPosition.y,
		                                                        "time", 1));
	}

	void onSendCardAniComplete( GameObject cv ){
		Destroy (cv);
	}

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		return receiver is IPlayPageDelegate;
	}
}