using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class PlayPage : SenderMono {

	Dictionary<int, GameObject> _hands = new Dictionary<int, GameObject> ();

	public GameObject go_hand;
	public GameObject go_hand2;
	public GameObject go_hand3;
	public GameObject go_hand4;
	public GameObject go_stack;
	public GameObject go_table;
	public GameObject go_score;

	private bool _onCardDown = false;
	private Vector3 _oldCardPosition;
	private Transform _cardTransform;

	// Use this for initialization
	protected override void Start () {
		base.Start ();

		_hands.Add( (int)EnumEntityID.Player1, go_hand );
		_hands.Add( (int)EnumEntityID.Player2, go_hand2 );
		_hands.Add( (int)EnumEntityID.Player3, go_hand3 );
		_hands.Add( (int)EnumEntityID.Player4, go_hand4 );

		Sender.Receivers.ToList().ForEach( obj => {
			((IPlayPageDelegate)obj).onPlayPageGameStart( this );
		});
		//StartCoroutine (delayAndPlay ());
	}

	//發牌給玩家
	public void DealCard( IDeck deck, IDeckPlayer player, ICard card  ){
		go_stack.GetComponent<StackView> ().dealCard (player, card);
		AddCard (deck, player, card);
	}

	//玩家抽一張卡
	public void AddCard( IDeck deck, IDeckPlayer player, ICard card ){
		_hands[ player.EntityID ].GetComponent<HandView> ().addCard (card);
	}

	//把牌丟到牌堆上
	public void PushCardToTable( IDeck deck, IDeckPlayer player, ICard card ){
		go_table.GetComponent<TableView> ().PushCardToTable (deck, player, card);
		SendCard (player.EntityID, _hands[ player.EntityID ].GetComponent<HandView> ().getCardViewByModel (card));
	}

	//改變目前數字
	public void GameNumberChanged(IGameState state, int number){
		go_score.GetComponent<ScoreView> ().GameNumberChanged (state, number);
	}

	//改變玩家
	public void DirectionChanged(IGameState state, Direction direction){
		go_score.GetComponent<ScoreView> ().DirectionChanged (state, direction);
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

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		return receiver is IPlayPageDelegate;
	}
}