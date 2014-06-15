using UnityEngine;
using System.Collections;
using System.Linq;

public class Model : SenderMono, IModel, IDeckDelegate, ICardAbilityReceiver, IMatchDelegate, IPlayerDelegate {
	IMatch _match = EntityManager.Singleton.Create<Match> ();

	public void StartGame(){
		_match.StartMatch ();
	}

	public void PlayerJoin(IOption<IPlayer> player){
		_match.PlayerJoin (player);
	}

	public void OnCurrentPlayerChange(IMatch match, IOption<IPlayer> player){

	}

	public void OnPlayerDraw(IDeck deck, IDeckPlayer player, ICard card){

	}

	public void OnCardPush(IDeck deck, IDeckPlayer player, ICard card){
		if (_match.CenterDeck == deck) {
			card.InvokeAbility(this);
		}
	}

	public void OnPlayerWillPushCard(IPlayer player, ICard card){
		player.Match.CenterDeck.Push (player, card);
	}

	public void OnPlayerWillDrawCard(IPlayer player){
		player.Match.Deck.Draw (player);
	}

	public IDeckPlayer CardOwner{ get{ return _match.CurrentPlayer.Instance; } }
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
		ICardAbilityReceiver car = _match.GameState as ICardAbilityReceiver;
		if (car != null) {
			car.AddNumber(number);
		}
		Pass (null);
	}
	public void Pass(IDeckPlayer owner){
		IPlayer player = owner as IPlayer;
		if (player != null) {
		}
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

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		bool isTarget = typeof(IInjectModel).IsAssignableFrom (receiver.GetType ());
		if (isTarget) {
			((IInjectModel)receiver).Model = this;
		}
		return false;
	}
}