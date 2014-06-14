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
	public IDeck Deck{ get{ return _deck; } }
	public IDeck CenterDeck{ get { return _centerDeck; } }
	public IGameState GameState{ get{ return _gameState; } }

	public void PlayerJoin(IOption<IPlayer> player){
		_players.Add (player);
	}
	public void PlayerLeave(IOption<IPlayer> player){
		_players.Remove (player);
	}
	public IOption<IPlayer> CurrentPlayer{
		get{ return _currentPlayer; } 
		set{
			if(_currentPlayer.Identity != value.Identity ){
				_currentPlayer = value;
				Sender.Receivers.ToList().ForEach(obj=>{
					((IMatchDelegate)obj).OnCurrentPlayerChange(this, _currentPlayer);
				});
			}
		} 
	}
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
		List<IOption<IPlayer>> l1 = _players;
		List<IOption<IPlayer>> l2 = _players.GetRange (1, _players.Count - 2);
		l2.Add (_players [0]);
		for (int i=0; i<l1.Count; ++i) {
			IPlayer p = l1[i].Instance;
			IPlayer n = l2[i].Instance;
			p.Next = l2[i];
			n.Prev = l1[i];
		}
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
		return receiver is IMatchDelegate;
	}
}