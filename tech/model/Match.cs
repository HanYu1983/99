using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Match : SenderAdapter, IMatch
{
	int _entityId;
	public int EntityID{ get{ return _entityId; } set{ _entityId = value; } }
	public EntityType EntityType{ get { return EntityType.Unknown; } }

	IDeck _deck = new Deck();
	IDeck _centerDeck = new Deck();
	IGameState _gameState = new GameState();
	List<IOption<IPlayer>> _players = new List<IOption<IPlayer>> ();
	IOption<IPlayer> _currentPlayer = Option<IPlayer>.None;

	public Match(){
		Card.AllCard.ToList().ForEach(card=>_deck.AddCard(card));
		_gameState.CenterDeck = _centerDeck;
	}
	public IDeck CenterDeck{ get { return _centerDeck; } }
	public IGameState GameState{ get{ return _gameState; } }

	public void PlayerJoin(IOption<IPlayer> player){
		if (_players.Count > 0) {
			_players[_players.Count-1].Map(prev=>{
				prev.Next = player;
			});
			player.Map(next=>{
				next.Prev = _players[_players.Count-1];
			});
		}
		_players.Add (player);
	}
	public void PlayerLeave(IOption<IPlayer> player){
		_players.Remove (player);
	}
	public IOption<IPlayer> CurrentPlayer{ get{ return _currentPlayer; } set{ _currentPlayer = value; } }
	public IList<IOption<IPlayer>> Players{ get{ return _players; } }
	public void StartMatch(){
		while (!_deck.IsNoCard) {
			_players.ForEach(op=>{
				op.Map(player=>{
					if(!_deck.IsNoCard){
						_deck.Draw(player);
					}
				});
			});
		}
		CurrentPlayer = Players [0];
	}
	public void Next(){
		CurrentPlayer.Map (player => player.Controller.Think ());
	}
	public void EndMatch(){

	}

	protected override bool HandleVerifyReceiverDelegate (object receiver){
		IInjectMatch target = receiver as IInjectMatch;
		if (target != null) {
			target.Match = this;
		}
		return false;
	}
}