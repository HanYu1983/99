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
		_players.Add (player);
	}
	public void PlayerLeave(IOption<IPlayer> player){
		_players.Remove (player);
	}
	public IOption<IPlayer> CurrentPlayer{ get{ return _currentPlayer; } set{ _currentPlayer = value; } }
	public IOption<IPlayer> NextPlayer{ 
		get{
			switch(GameState.Direction){
			case Direction.Forward:
				return CurrentPlayer.Instance.Next;
			case Direction.Backward:
				return CurrentPlayer.Instance.Prev;
			}
			return Option<IPlayer>.None;
		}
	}
	public IList<IOption<IPlayer>> Players{ get{ return _players; } }
	void MakePlayerCircleLink(){

	}
	public void StartMatch(){
		MakePlayerCircleLink ();
		_players.ForEach(op=>{
			op.Map(player=>{
				for(int i=0; i<4; ++i){
					_deck.Draw(player);
				}
			});
		});
		CurrentPlayer = Players [0];
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