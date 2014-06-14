using UnityEngine;
using System.Collections;
using System.Linq;

public class Model : SenderAdapter, IModel, IDeckDelegate, ICardAbilityReceiver {
	IMatch _match = new Match();

	public void StartMatch(){
		_match.StartMatch ();
	}

	public void OnPlayerDraw(IDeck deck, IDeckPlayer player, ICard card){

	}

	public void OnCardPush(IDeck deck, IDeckPlayer player, ICard card){
		if (_match.CenterDeck == deck) {
			card.InvokeAbility(this);
		}
	}

	public IDeckPlayer CardOwner{ get{ return null; } }
	public Direction Direction{ 
		get{ return _match.GameState.Direction; }
		set{ 
			ICardAbilityReceiver car = _match.GameState as ICardAbilityReceiver;
			if (car != null) {
				car.Direction = value;
			} 
		} 
	}
	public void AddNumber(int number){ 
		_match.GameState.AddNumber (number);
		Pass (null);
	}
	public void Pass(IDeckPlayer owner){
		_match.CurrentPlayer = null;
	}
	public void FullNumber(){
		ICardAbilityReceiver car = _match.GameState as ICardAbilityReceiver;
		if (car != null) {
			car.FullNumber();
		}
		Pass (null);
	}
	public void AssignPlayer(IDeckPlayer owner){
		IPlayer p = owner as IPlayer;
		if (p != null) {
			p.Controller.AssignPlayer(owner);
		}
	}
	public void ControlNumber(int number, IDeckPlayer owner){
		IPlayer p = owner as IPlayer;
		if (p != null) {
			p.Controller.ControlNumber(number, owner);
		}
		Pass (null);
	}
}