using UnityEngine;
using System.Collections;
using System.Linq;

public class GameState : SenderAdapter, IGameState, IDeckDelegate, ICardAbilityReceiver
{
	int _entityId;
	public int EntityID{ get{ return _entityId; } set{ _entityId = value; } }
	public EntityType EntityType{ get { return EntityType.Unknown; } }

	IDeck _centerDeck;
	Direction _direction = Direction.Forward;
	int _currentNumber;

	public IDeck CenterDeck{ 
		get{ return _centerDeck; } 
		set{ _centerDeck = value; _centerDeck.DeckDelegate = this;} 
	}
	public int CurrentNumber{ 
		get{ return _currentNumber; }
	}
	public bool IsOutOf99{ get{ return CurrentNumber > 99; } }

	public void OnCardPush(IDeck deck, IDeckPlayer player, ICard card){
		Sender.Receivers.ToList().ForEach(obj=>{
			((IGameStateDelegate)obj).OnCardPush(deck, player, card);
		});
	}

	public IDeckPlayer CardOwner{ get{ return null; } }
	public Direction Direction{ get{ return _direction; } set{ _direction = value; } }
	public void AddNumber(int number){ 
		_currentNumber += number;
	}
	public void Pass(IDeckPlayer owner){

	}
	public void FullNumber(){
		_currentNumber = 99;
	}
	public void AssignPlayer(IDeckPlayer owner){
		/*
		IPlayer p = owner as IPlayer;
		if (p != null) {
			p.Controller.AssignPlayer(owner);
		}
		*/
	}
	public void ControlNumber(int number, IDeckPlayer owner){
		/*
		IPlayer p = owner as IPlayer;
		if (p != null) {
			p.Controller.ControlNumber(number, owner);
		}
		*/
	}

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		return typeof(IGameStateDelegate).IsAssignableFrom (receiver.GetType ());
	}
}