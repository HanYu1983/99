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
	public GameObject go_playerBorder;
	
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

		//因為玩家自己丟出牌的動畫已經經由操作執行了，這時只需要執行其他玩家的動畫就可以了
		//當玩家也是ai的時候，先mark掉來測試
		//if( player.EntityID != (int)EnumEntityID.Player1 )
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
	public void SendCard( int playerId, GameObject cardView ){
		if(cardView != null){
			iTween.ScaleTo (cardView, iTween.Hash (	"x", 0,
		    	                                    "y", 0,
		        	                                "time", 1,
		            	                           	"oncomplete","onSendCardAniComplete",
		                	                       	"oncompletetarget", this.gameObject,
		                    	                   	"oncompleteparams", cardView));
			_hands[ playerId ].GetComponent<HandView> ().subCard (cardView);
		}
	}

	//由border所傳進來的touch Y 事件
	public void moveCardByBorder( float moveY ){
		go_hand.GetComponent<HandView> ().moveCardByBorder (moveY);
	}

	//由border所傳進來的focus card事件
	public void focusCardByBorderPer( float per ){
		go_hand.GetComponent<HandView> ().focusCardByBorderPer (per);
	}

	//由border所傳進來的release card事件
	public void releaseCardByBorder( float moveY ){
		go_hand.GetComponent<HandView> ().releaseCardByBorder (moveY);
	}

	void onSendCardAniComplete( GameObject cv ){
		Destroy (cv);
		Sender.Receivers.ToList().ForEach( obj => {
			((IPlayPageDelegate)obj).onPlayPageSendCard( this, cv.GetComponent<CardViewConfig>().cardModel );
		});
	}
	
	void onTouchConsumerEventMouseDown( TouchEvent te ){
		switch (te.name) {
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