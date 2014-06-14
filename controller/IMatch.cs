using UnityEngine;
using System.Collections.Generic;

public interface IMatch : IEntity
{
	IDeck CenterDeck{ get; }
	IGameState GameState{ get; }
	void PlayerJoin(IOption<IPlayer> player);
	void PlayerLeave(IOption<IPlayer> player);
	IOption<IPlayer> CurrentPlayer{ get; set; }
	IList<IOption<IPlayer>> Players{ get; }
	void StartMatch();
	void Next();
	void EndMatch();
}