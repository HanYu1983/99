using UnityEngine;
using System.Collections;
using System.Linq;

public class GameState : IGameState, IDeckDelegate, ICardAbilityReceiver
{
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
	public Direction CurrentDirection{ get{ return _direction; } }
	
	public void OnCardPush(IDeck deck, IDeckPlayer player, ICard card){
		_cardPushOwner = player;
		card.InvokeAbility (this);
	}

	void ClampNumberTo99(){
		if (_currentNumber > 99)
			_currentNumber = 99;
	}

	IDeckPlayer _cardPushOwner;
	public IDeckPlayer CardOwner{ get{ return _cardPushOwner; } }
	public Direction Direction{ get{ return _direction; } set{ _direction = value; } }
	public void AddNumber(int number){ 
		_currentNumber += number;
		ClampNumberTo99 ();
	}
	public void AssignPlayer(IDeckPlayer owner){

	}
	public void ControlNumber(int number, IDeckPlayer owner){

	}
}