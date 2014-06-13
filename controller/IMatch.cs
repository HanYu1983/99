using UnityEngine;
using System.Collections.Generic;

public interface IMatch
{
	void PlayerJoin(IOption<IPlayer> player);
	void PlayerLeave(IOption<IPlayer> player);
	IOption<IPlayer> CurrentPlayer{ get; }
	IList<IOption<IPlayer>> Players{ get; }
	void StartMatch();
	void Next();
	void EndMatch();
}